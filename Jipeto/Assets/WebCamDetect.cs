using UnityEngine;

public class WebCamDetect : MonoBehaviour
{

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log("Number of web cams connected: " + devices.Length);

        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(i + " " + devices[i].name);
        }

        Renderer rend = this.GetComponent<Renderer>();

        WebCamTexture mycam = new WebCamTexture();
        string camName = devices[0].name;
        Debug.Log("The webcam name is " + camName);
        mycam.deviceName = camName;
        rend.material.mainTexture = mycam;

        mycam.Play();
    }
}