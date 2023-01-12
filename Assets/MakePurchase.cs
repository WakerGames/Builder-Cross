using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePurchase : MonoBehaviour
{

    private void OnEnable()
    {
        PurchaseManager.Instance.OnPurchase += OnPurchaseAction;
    }
    private void OnDisable()
    {
        PurchaseManager.Instance.OnPurchase -= OnPurchaseAction;
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
        PurchaseManager.Instance.RemoveAdsCompleted();
    }
    public void RestorePurchase()
    {
        PurchaseManager.Instance.RestorePurchases();
    }
    
}
