using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camer_setting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject self;
    public Camera cameras;
    private Texture2D screenTexture;
    private byte[] imagedata;
    void Start()
    {
        int width = cameras.targetTexture.width;
        int height = cameras.targetTexture.width;
        screenTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
    }

    // Update is called once per frame
    private void OnPostRender()
    {
        screenTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenTexture.Apply();
        if (screenTexture != null)
        {
            string imageBase64 = System.Convert.ToBase64String(screenTexture.EncodeToJPG());
            self.GetComponent<camera_output>().add_frame(imageBase64);
        }
    }
    private void OnApplicationQuit()
    {
        if (screenTexture != null)
        {
            Destroy(screenTexture);
        }
    }
}
