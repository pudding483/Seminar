using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class player_view : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 3f;
    [SerializeField] float turning_speed = 2f;
    public string std_id = "";
    void Start()
    {
        transform.Translate(0, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (std_id == "110590009")
        {
            transform.position = transform.position - transform.rotation * Vector3.forward * speed / 100;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + transform.rotation * Vector3.forward * speed / 100;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position - transform.rotation * Vector3.forward * speed / 100;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 player_forward = transform.rotation * Vector3.forward;
            transform.rotation = Quaternion.Euler(0, turning_speed / 10, 0) * transform.rotation;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 player_forward = transform.rotation * Vector3.forward;
            transform.rotation = Quaternion.Euler(0, -1 * turning_speed / 10, 0) * transform.rotation;
        }
    }
}
