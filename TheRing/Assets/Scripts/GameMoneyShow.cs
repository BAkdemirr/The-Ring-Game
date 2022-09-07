using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMoneyShow : MonoBehaviour
{
    [SerializeField] private TMP_Text gameMoney;
    public int moneyGame;

    private void Update()
    {
        
        gameMoney.text = "Money: " + PlayerPrefs.GetInt("money").ToString();
    }
}
