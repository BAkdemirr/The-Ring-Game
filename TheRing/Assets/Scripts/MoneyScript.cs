using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyScript : MonoBehaviour
{
    public static MoneyScript ms;
    public int money = 0;
    //public TextMeshProUGUI text;


    //private void Awake()
    //{
    //    if (ms == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        ms = this;
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
    }

    private void Update()
    {
        //   PlayerPrefs.SetInt("money", money);
        //PlayerPrefs.DeleteAll();
        //text.text = money.ToString();
    }

}
