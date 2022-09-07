using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private bool musicEnable;
    [SerializeField] private AudioSource music;

    public static MusicController mc;

    private void Awake()
    {
        if (mc == null)  
        {
            DontDestroyOnLoad(gameObject);
            mc = this;
            musicEnable = true;

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
            music.volume = PlayerPrefs.GetFloat("MusicVolume");
            if (music.volume == 1) 
            {
                musicEnable = true;
            }
            else
            {
                musicEnable = false;
            }
        }

        
    }

    public void ToggleMusic()
    {
        if (!musicEnable) 
        {
            music.Play();
            PlayerPrefs.SetFloat("MusicVolume", 1.0f);
            music.volume = 1;
            musicEnable = true;
        }
        else
        {
            music.Pause();
            PlayerPrefs.SetFloat("MusicVolume", 0);
            music.volume = 0;
            musicEnable = false;
        }
    }

}
