using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSoundVolume : MonoBehaviour
{
    [SerializeField] private GameObject music;

    public static MasterSoundVolume msv;

    [SerializeField] private Image soundOn;
    [SerializeField] private Image soundOff;

    private void Awake()
    {
        if (msv == null) 
        {
            DontDestroyOnLoad(gameObject);
            msv = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume")) 
        {
            music.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("MasterVolume")) 
        {
            Camera.main.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MasterVolume");
        }

        UpdateIcon();
    }


    public void MasterSoundToggle()
    {
        if (music.GetComponent<AudioSource>().volume == 0 && Camera.main.GetComponent<AudioSource>().volume == 0)
        {
            music.GetComponent<AudioSource>().volume = 1;
            PlayerPrefs.SetFloat("MusicVolume", 1.0f);
            Camera.main.GetComponent<AudioSource>().volume = 1;
            PlayerPrefs.SetFloat("MasterVolume", 1.0f);
        }
        else
        {
            music.GetComponent<AudioSource>().volume = 0;
            PlayerPrefs.SetFloat("MusicVolume", 0);
            Camera.main.GetComponent<AudioSource>().volume = 0;
            PlayerPrefs.SetFloat("MasterVolume", 0);
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (Camera.main.GetComponent<AudioSource>().volume == 1)
        {
            soundOn.enabled = true;
            soundOff.enabled = false;
        }
        else
        {
            soundOn.enabled = false;
            soundOff.enabled = true;
        }
    }

}
