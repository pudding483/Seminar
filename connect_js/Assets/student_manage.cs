using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class student_manage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject student_prefab;
    public Dictionary<string, GameObject> std_list = new Dictionary<string, GameObject>();
    public void studentspawn(string id, string url)
    {
        if (student_prefab != null && !std_list.ContainsKey(id))
        {
            GameObject student = Instantiate(student_prefab, transform.position, transform.rotation);
            student.GetComponent<player_move>().init(id, url);
            std_list[id] = student;
        }
    }
    public void testing(string id, string cmd)
    {
        if (std_list.ContainsKey(id))
        {
            std_list[id].GetComponent<player_move>().move_cmd(cmd);
        }
    }
}