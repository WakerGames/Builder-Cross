using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdShower : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("REMOVEADS"));

    }
    void Start()
    {
        Debug.Log("AdCount ======= " + PlayerPrefs.GetInt("ADCOUNT"));
        //if (PlayerPrefs.GetInt("REMOVEADS") == 1)
        //    return;
        //if (AdManager.Instance != null)
        //{

        //    PlayerPrefs.SetInt("ADCOUNT", PlayerPrefs.GetInt("ADCOUNT") + 1);
        //    if (PlayerPrefs.GetInt("ADCOUNT") % 3 == 0)
        //    {
        //        AdManager.Instance.AdPlay();
        //    }
        //}

        StartCoroutine(AdShowCourutine());

    }
    public IEnumerator AdShowCourutine()
    {
        if (PlayerPrefs.GetInt("REMOVEADS") == 0)
        {
            #if !play_build
            yield return new WaitUntil(() => AdsDemoManager.Instance != null);
            {

                PlayerPrefs.SetInt("ADCOUNT", PlayerPrefs.GetInt("ADCOUNT") + 1);
                if (PlayerPrefs.GetInt("ADCOUNT") % 3 == 0)
                {
                    AdsDemoManager.Instance.ShowInterstitialAd();
                }
            }
            #else
            yield return null; 
            #endif
        }




    }
}
