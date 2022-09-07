using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopOpenMainMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    public void OpenShopMenu()
    {
        SceneManager.LoadScene(2);
    }
}
