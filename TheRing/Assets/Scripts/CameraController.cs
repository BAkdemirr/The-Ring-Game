using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.1f;

    //static CameraController camController;

    //private void Awake()
    //{
    //    if (camController == null) 
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        camController = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if (PlayerPrefs.GetFloat("MasterVolume") == 0) 
        {
            Camera.main.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            Camera.main.GetComponent<AudioSource>().volume = 1;
        }
    }
}
