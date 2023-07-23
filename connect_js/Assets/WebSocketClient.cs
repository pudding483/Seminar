using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
public class WebSocketClient : MonoBehaviour
{
    public WebSocket ws;
    public GameObject Students;
    private Transform parentTransform;
    bool ws_appear()
    {
        return ws != null && ws.ReadyState == WebSocketState.Open;
    }

    void Start()
    {
        string serverUrl = "ws://localhost:5000"; // 服务器的 WebSocket 地址
        ws = new WebSocket(serverUrl);

        ws.OnOpen += OnOpen;
        ws.OnMessage += OnMessage;
        ws.OnClose += OnClose;

        ws.Connect();
        parentTransform = transform.parent;
    }

    void OnOpen(object sender, System.EventArgs e)
    {
        Debug.Log("Connected to server");
        sendvarify();
    }

    void OnMessage(object sender, MessageEventArgs e)
    {
        Dictionary<string, string> msg = JsonConvert.DeserializeObject<Dictionary<string, string>>(e.Data);
        if (msg["type"].Equals("website_ws"))
        {

            spawnstudent(msg["clientId"]);
            Debug.Log("生成學生" + msg["clientId"]);
        }
    }

    void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Connection closed");
        // 在连接关闭时执行一些清理操作
    }

    void OnDestroy()
    {
        if (ws_appear())
        {
            ws.Close();
        }
    }

    public void sendvarify()
    {
        if (ws_appear())
        {
            string vari = "{\"type\": \"unity_ws\"}";
            ws.Send(vari);
        }
    }
    public void spawnstudent(string id)
    {
        Debug.Log("123");
        GameObject newStudent = Instantiate(Students, parentTransform);
        player_view playerViewScript = newStudent.GetComponent<player_view>();
        if (playerViewScript != null)
        {
            playerViewScript.std_id = id;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ws_appear())
        {
            string jsonStr = "123456789";
            Debug.Log(jsonStr);
            ws.Send(jsonStr);
        }
    }
}
