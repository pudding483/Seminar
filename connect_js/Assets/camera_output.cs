using UnityEngine;
using WebSocketSharp;
using System.IO;
using System.Collections;
using System.Collections.Generic;
public class camera_output : MonoBehaviour
{
    private WebSocket ws;
    public string std_id;
    public string std_url;
    private List<string> image_file = new List<string>();

    void Start()
    {
        while (std_id == null && std_url == null)
        {
            Debug.Log("loading");
        }
        ws = new WebSocket(std_url);
        ws.Connect();
    }
    public void add_frame(string frame)
    {
        string f ="{\"type\":\"unity_cam\", \"clientId\":\"" + std_id + "\", \"image\":\"" + frame + "\"}";
        image_file.Add(f);
    }
    void Update()
    {
        if (image_file.Count > 0)
        {
            ws.Send(image_file[0]);
            image_file.RemoveAt(0);
        }

    }

}
