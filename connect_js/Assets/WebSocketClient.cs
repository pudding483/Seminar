using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
public class WebSocketClient : MonoBehaviour
{
    public WebSocket ws;
    public student_manage sm;
    public string serverUrl = "ws://localhost:5000";
    private List<string> std_list = new List<string>();
    private List<List<string>> std_moves = new List<List<string>>();

    bool ws_appear()
    {
        return ws != null && ws.ReadyState == WebSocketState.Open;
    }

    void Start()
    {
        ws = new WebSocket(serverUrl);

        ws.OnOpen += OnOpen;
        ws.OnMessage += OnMessage;
        ws.OnClose += OnClose;

        ws.Connect();
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
            std_list.Add(msg["clientId"]);
            Debug.Log("生成學生" + msg["clientId"]);
        }
        if (msg["type"].Equals("web_message"))
        {
            List<string> move = new List<string> { msg["clientId"], msg["command"] };
            std_moves.Add(move);

        }
    }

    void OnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("Connection closed");
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ws_appear())
        {
            string jsonStr = "123456789";
            Debug.Log(jsonStr);
            ws.Send(jsonStr);
        }
        if (std_list.Count > 0)
        {
            sm.studentspawn(std_list[0], serverUrl);
            std_list.RemoveAt(0);
        }
        if (std_moves.Count > 0)
        {
            sm.testing(std_moves[0][0], std_moves[0][1]);
            std_moves.RemoveAt(0);
        }
    }
}
