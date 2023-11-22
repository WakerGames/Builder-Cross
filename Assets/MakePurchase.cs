using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePurchase : MonoBehaviour
{

    private void OnEnable()
    {
#if !play_build
        IapDemoManager.OnPurchase += OnPurchaseAction;
#endif
    }
    private void OnDisable()
    {
#if !play_build
        IapDemoManager.OnPurchase -= OnPurchaseAction;
#endif
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("REMOVEADS") == 1)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }


    void Update()
    {

    }

    public void OnPurchaseAction()
    {
        GetComponent<Button>().interactable = false;
    }
    public void MakePurchaseButton()
    {
#if !play_build
        IapDemoManager.Instance.PurchaseProduct("remove_ads_hs");
#endif
        
    }
    public void RestorePurchase()
    {
        PurchaseManager.Instance.RestorePurchases();
    }

}
