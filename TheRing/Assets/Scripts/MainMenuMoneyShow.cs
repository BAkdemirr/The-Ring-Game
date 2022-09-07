using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuMoneyShow : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = PlayerPrefs.GetInt("money").ToString();
    }
}
