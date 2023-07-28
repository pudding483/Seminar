using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
public class player_move : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private string std_url = "";
    public string std_id = "";
    private List<string> movement_list = new List<string>();
    
    void Start()
    {
        
    }
    void Update()
    {
        if (movement_list.Count > 0)
        {
            switch (movement_list[0])
            {
                case "1":
                    transform.position += transform.rotation * Vector3.forward * speed / 100;
                    break;
                case "2":
                    transform.position += transform.rotation * Vector3.back * speed / 100;
                    break;
                case "3":
                    transform.position += transform.rotation * Vector3.left * speed / 100;
                    break;
                case "4":
                    transform.position += transform.rotation * Vector3.right * speed / 100;
                    break;
            }
            movement_list.RemoveAt(0);
        }
    }
    public void init(string id, string url)
    {
        if (id != null)
        {
            std_id = id;
        }
        if (url != null)
        {
            std_url = url;
        }

    }
}
