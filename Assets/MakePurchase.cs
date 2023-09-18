using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePurchase : MonoBehaviour
{

    private void OnEnable()
    {
        IapDemoManager.OnPurchase += OnPurchaseAction;
    }
    private void OnDisable()
    {
        IapDemoManager.OnPurchase -= OnPurchaseAction;
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
        IapDemoManager.Instance.PurchaseProduct("remove_ads_hs");
        
    }
    public void RestorePurchase()
    {
        PurchaseManager.Instance.RestorePurchases();
    }

}
