using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNoDestroyMainMeny : MonoBehaviour
{
    public static CanvasNoDestroyMainMeny noDestroyCanvasMainMenu;

    private void Awake()
    {
        if (noDestroyCanvasMainMenu == null)
        {
            DontDestroyOnLoad(gameObject);
            noDestroyCanvasMainMenu = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
