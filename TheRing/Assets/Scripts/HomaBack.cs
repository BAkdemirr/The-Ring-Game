using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomaBack : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void BackHomeBtn(int sceneIndex)
    {
        GameManager.gm.isPlayerAlive = true;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }
}
