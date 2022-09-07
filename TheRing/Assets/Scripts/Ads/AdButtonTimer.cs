using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class AdButtonTimer : MonoBehaviour
{
    [SerializeField] private Button adButtonTimer;
    private ulong lastTimeChestOpen;
    public float waitTime = 5000.0f;
    public TMP_Text timer_text;

    public UnityAds unityAds;

    public bool isButtonClicked = false;

    public int moneySayaci;

    private void Start()
    {
        lastTimeChestOpen = ulong.Parse(PlayerPrefs.GetString("ChestClicked", "0"));

        moneySayaci = PlayerPrefs.GetInt("money");

        if (!IsAdReady())
        {
            adButtonTimer.interactable = false;
        }
    }

    private void Update()
    {
        if (!adButtonTimer.IsInteractable())
        {
            if (IsAdReady())
            {
                adButtonTimer.interactable = true;
                return;
            }

            // Set the timer
            ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeChestOpen);
            ulong tickToMillisecond = diff / TimeSpan.TicksPerMillisecond;
            float secondsLeft = (float)(waitTime - tickToMillisecond) / 1000.0f;

            // bunu yazdırıyoruz
            string r = "";
            // Hours
            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;
            // minutes
            r += ((int)secondsLeft / 60).ToString("F0") + "m ";
            // seconds
            r += (secondsLeft % 60).ToString("F0") + "s";

            timer_text.text = r;
        }
    }


    public void ButtonClicked()
    {
        isButtonClicked = true;
        lastTimeChestOpen = (ulong)DateTime.Now.Ticks;
        PlayerPrefs.SetString("ChestClicked", lastTimeChestOpen.ToString());
        adButtonTimer.interactable = false;

        // case opening or giving reward here
        unityAds.ShowVideoAd(GameManager.gm.OnRewardAdSuccess);


        //moneySayaci = PlayerPrefs.GetInt("money");
        //moneySayaci += 500;
        //PlayerPrefs.SetInt("money", moneySayaci);

        moneySayaci = PlayerPrefs.GetInt("money");
        moneySayaci += 500;
        PlayerPrefs.SetInt("money", moneySayaci);

    }

    private bool IsAdReady()
    {
        ulong diff = ((ulong)DateTime.Now.Ticks - lastTimeChestOpen);
        ulong tickToMillisecond = diff / TimeSpan.TicksPerMillisecond;

        float secondsLeft = (float)(waitTime - tickToMillisecond) / 1000.0f;

        if (secondsLeft < 0)
        {
            timer_text.text = "Ready";
            return true;
        }

        return false;
    }


}
