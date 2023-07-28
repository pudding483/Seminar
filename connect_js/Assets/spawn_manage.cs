using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manage : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject s;
    public void studentspawn(string id, string url)
    {
        if (s != null)
        {
            GameObject std = Instantiate(s, transform.position, transform.rotation);
            player_move targetScript = std.GetComponent<player_move>();
            if (targetScript != null)
            {
                targetScript.init(id, url);
            }

        }
    }

}
