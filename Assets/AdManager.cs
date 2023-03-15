using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener, IUnityAdsInitializationListener
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
            Debug.Log("Destroyed");
        }
        else
        {
            Debug.Log("instantiated");
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        Advertisement.Initialize(gameId, false, this);
        Advertisement.Load(normalAd, this);
        Advertisement.Load(rewardedAd, this);

    }

    
    public void AdPlay()
    {
        Debug.Log("- AdPlay -");
        Advertisement.Show(normalAd, this);

    }
    public void RewardedAdPlay()
    {
        Advertisement.Show(rewardedAd, this);
    }

    void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log(error.ToString() + message);
    }

    void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
    {
        Time.timeScale = 0f;

    }

    void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
    {
       
    }

    void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1f;
    }

    void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        Debug.Log(" ADS Ready");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log(error.ToString() + message);
    }
}
