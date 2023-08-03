using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using Newtonsoft.Json;
public class player_move : MonoBehaviour
{
    [SerializeField] float speed = 75f;
    private string std_url;
    [SerializeField] string std_id;
    private List<string> movement_list = new List<string>();
    public GameObject self;

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
        if (id != null && url != null)
        {
            std_id = id;
            std_url = url;
            self.GetComponent<camera_output>().std_id = id;
            self.GetComponent<camera_output>().std_url = url;
        }
    }
    public void move_cmd(string cmd)
    {
        movement_list.Add(cmd);
    }
    public string get_id()
    {
        return std_id;
    }
    public string get_url()
    {
        return std_id;
    }
}
