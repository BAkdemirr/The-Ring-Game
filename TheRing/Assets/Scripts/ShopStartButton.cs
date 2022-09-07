using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopStartButton : MonoBehaviour
{
    public void StartSceneFunc()
    {
        SceneManager.LoadScene(1);
    }
}
