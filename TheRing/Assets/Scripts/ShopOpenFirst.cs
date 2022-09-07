using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopOpenFirst : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void OpenShop()
    {
        gameOverPanel.SetActive(false);
        GameManager.gm.isPlayerAlive = true;
        SceneManager.LoadScene(2);
    }
}
