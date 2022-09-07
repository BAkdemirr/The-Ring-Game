using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject distanceValue;


    //public static PauseMenu pauseM;

    //private void Awake()
    //{
    //    if (pauseM == null) 
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        pauseM = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public void PauseBtn()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeBtn()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HomeBtn(int sceneIndex)
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        this.gameObject.SetActive(false);
        distanceValue.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShopBtn()
    {

    }

}
