using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver_panel;

    private TMP_Text distance_value;

    public static UIManager ui_m;

    private RectTransform health_bar;

    [SerializeField] private TMP_Text highsocre_text;

    //public int money;
    //public TMP_Text money_text;

    private void Awake()
    {
        if (ui_m == null) 
        {
            DontDestroyOnLoad(gameObject);
            ui_m = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void OpenGameOverUI()
    {
        if (gameOver_panel != null) 
        {
            gameOver_panel.SetActive(true);
        }
    }

    public void SetDistanceValue(float distance)
    {
        distance_value = GameObject.FindGameObjectWithTag("distancevalueLayer").GetComponent<TextMeshProUGUI>();
        distance_value.text = distance.ToString("f1");
    }

    public void SetPlayerHealth(float health)
    {
        health_bar = GameObject.FindGameObjectWithTag("healthbarrectLayer").GetComponent<RectTransform>();
        health_bar.localScale = new Vector3(health / 10, 1f, 1f);
    }

    public void SetHighscoreText()
    {
        highsocre_text.text = PlayerPrefs.GetFloat("Highscore").ToString("F1");
    }

    //public void SetMoney()
    //{
    //    money = PlayerPrefs.GetInt("Money");
    //    money_text.text = money.ToString();
    //}

}
