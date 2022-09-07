using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    public GameObject gameOverPanel;
    //public GameObject gamePanel;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void TryAgain()
    {
        gameOverPanel.SetActive(false);
        //gamePanel.SetActive(true);
        GameManager.gm.isPlayerAlive = true;
        SceneManager.LoadScene("First");
        

    }
}
