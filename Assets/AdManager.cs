using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
 string gameId = "5113055";
 string normalAd = "Interstitial_iOS";
 string rewardedAd= "Rewarded_iOS";
 string banner = "Banner_iOS";
 
#else
    string gameId = "5113054";
    string normalAd = "Interstitial_Android";
    string rewardedAd = "Rewarded_Android";
    string banner = "Banner_Android";



#endif
    private static AdManager _instance;

    public static AdManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Advertisement.Initialize(gameId);
        Advertisement.AddListener(this);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        Debug.Log(" ADS Error");
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Time.timeScale = 1f;
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        Time.timeScale = 0f;
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        Debug.Log(" ADS Ready");
    }
    public void AdPlay()
    {

        if (Advertisement.IsReady(normalAd))
        {
            Advertisement.Show(normalAd);
        }
    }
    public void RewardedAdPlay()
    {
        if (Advertisement.IsReady(rewardedAd))
        {
            Advertisement.Show(rewardedAd);
        }
    }
}
