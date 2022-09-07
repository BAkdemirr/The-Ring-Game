using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopMoneyShow : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "Money: " + PlayerPrefs.GetInt("money").ToString() + "$";
    }
}
