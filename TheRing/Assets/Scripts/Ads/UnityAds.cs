using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
#if UNITY_ANDROID
    [SerializeField] string gameId = "4417313";
#elif UNITY_IOS
    [SerializeField] string gameId = "4417312";
#endif


    [SerializeField] bool testMode = true;

    string interstitialAdUnit_id = "interstitialAds";
    string rewardedVideoAdUnit_id = "Rewarded_Android";

    Action onRewardedAdSuccess;
    public static UnityAds unityAds;

    private void Awake()
    {
        if (unityAds == null)
        {
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(gameId, testMode);
            Advertisement.AddListener(this);
            unityAds = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        
    }

    public void ShowInterstitialAd()
    {
        if (Advertisement.IsReady(interstitialAdUnit_id))
        {
            Advertisement.Show(interstitialAdUnit_id);
        }
        else
        {
            print("Error interstitial ad is not ready");
        }
        
    }

    public void ShowVideoAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess; 
        if (Advertisement.IsReady(rewardedVideoAdUnit_id))
        {
            Advertisement.Show(rewardedVideoAdUnit_id);
        }
        else
        {
            print("Error rewarded video ad is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        print("Ads ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        print("Error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        print("Ad Started");
        Camera.main.GetComponent<AudioSource>().volume = 0;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == rewardedVideoAdUnit_id && showResult == ShowResult.Finished)
        {
            onRewardedAdSuccess.Invoke();
            Camera.main.GetComponent<AudioSource>().volume = 1;
        }
        
        else if (showResult == ShowResult.Failed)
        {
            Camera.main.GetComponent<AudioSource>().volume = 1;
        }
        else if (showResult == ShowResult.Skipped)
        {
            Camera.main.GetComponent<AudioSource>().volume = 1;
        }
    }
}