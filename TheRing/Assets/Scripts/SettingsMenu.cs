using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject MainMenu_panel;
    public GameObject Credits_panel;

    public void OpenCredits()
    {
        if (MainMenu_panel != null) 
        {
            MainMenu_panel.SetActive(false);
            if (Credits_panel != null) 
            {
                Credits_panel.SetActive(true);
            }
            
        }
    }

    public void BackBtn()
    {
        MainMenu_panel.SetActive(true);
        Credits_panel.SetActive(false);
    }
}
