using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNoDestroy : MonoBehaviour
{
    public static CanvasNoDestroy noDestroyCanvas;

    private void Awake()
    {
        if (noDestroyCanvas == null) 
        {
            DontDestroyOnLoad(gameObject);
            noDestroyCanvas = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
