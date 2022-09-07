using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int currentRingIndex;
    public GameObject[] ringModels;

    public RingBluePrint[] ringBlueprint;
    public Button buyBtn;

    private void Start()
    {

        //set isunlocked for all elements
        foreach (RingBluePrint ring in ringBlueprint)
        {
            if (ring.price == 0)
                ring.isUnlocked = true;
            else
                ring.isUnlocked = PlayerPrefs.GetInt(ring.name, 0) == 0 ? false : true;
        }


        currentRingIndex = PlayerPrefs.GetInt("SelectedRing", 0);

        foreach (GameObject ring in ringModels)
            ring.SetActive(false);

        ringModels[currentRingIndex].SetActive(true);

    }

    private void Update()
    {
        UpdateUI();
    }

    public void ChangeNext()
    {
        ringModels[currentRingIndex].SetActive(false);
        currentRingIndex++;
        if (currentRingIndex == ringModels.Length)
            currentRingIndex = 0;
        ringModels[currentRingIndex].SetActive(true);

        RingBluePrint r = ringBlueprint[currentRingIndex];
        if (!r.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedRing", currentRingIndex);
    }

    public void ChangePrevious()
    {
        ringModels[currentRingIndex].SetActive(false);
        currentRingIndex--;
        if (currentRingIndex == -1)
            currentRingIndex = ringModels.Length - 1;
        ringModels[currentRingIndex].SetActive(true);

        RingBluePrint r = ringBlueprint[currentRingIndex];
        if (!r.isUnlocked)
            return;

        PlayerPrefs.SetInt("SelectedRing", currentRingIndex);
    }

    public void UnlockRing()
    {
        RingBluePrint r = ringBlueprint[currentRingIndex];
        PlayerPrefs.SetInt(r.name, 1);
        PlayerPrefs.SetInt("SelectedRing", currentRingIndex);
        r.isUnlocked = true;
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) - r.price);

    }

    private void UpdateUI()
    {
        RingBluePrint r = ringBlueprint[currentRingIndex];
        if (r.isUnlocked)
        {
            buyBtn.gameObject.SetActive(false);
        }
        else
        {
            buyBtn.gameObject.SetActive(true);
            buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "BUY   $" + r.price;
            if (r.price > PlayerPrefs.GetInt("money"))
            {
                buyBtn.interactable = false;
            }
            else
            {
                buyBtn.interactable = true;
            }
        }


    }
}
