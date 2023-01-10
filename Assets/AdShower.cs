using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdShower : MonoBehaviour
{

    private void Awake()
    {


    }
    void Start()
    {
        if (PlayerPrefs.GetInt("REMOVEADS") == 1)
            return;
        if (AdManager.Instance != null)
        {

            PlayerPrefs.SetInt("ADCOUNT", PlayerPrefs.GetInt("ADCOUNT") + 1);
            if (PlayerPrefs.GetInt("ADCOUNT") % 3 == 0)
            {


                AdManager.Instance.AdPlay();

            }
        }

    }


    void Update()
    {

    }
}
