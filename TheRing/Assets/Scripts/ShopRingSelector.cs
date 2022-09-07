using UnityEngine;

public class ShopRingSelector : MonoBehaviour
{
    public int currentRingIndex;
    public GameObject[] rings;

    private void Start()
    {
        currentRingIndex = PlayerPrefs.GetInt("SelectedRing", 0);

        foreach (GameObject ring in rings)
            ring.SetActive(false);

        rings[currentRingIndex].SetActive(true);

    }
}
