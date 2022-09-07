using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopHomeButton : MonoBehaviour
{
    public void OpenMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
