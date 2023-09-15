using HmsPlugin;

using HuaweiMobileServices.IAP;
using HuaweiMobileServices.Utils;

using System;
using System.Collections.Generic;

using UnityEngine;

public class IapDemoManager : MonoBehaviour
{
    // Please insert your products via custom editor. You can find it in Huawei > Kit Settings > IAP tab.

    public static Action<string> IAPLog;

    List<InAppPurchaseData> consumablePurchaseRecord = new List<InAppPurchaseData>();
    List<InAppPurchaseData> activeNonConsumables = new List<InAppPurchaseData>();
    List<InAppPurchaseData> activeSubscriptions = new List<InAppPurchaseData>();

    #region Singleton

    public static IapDemoManager Instance { get; private set; }
    private void Singleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    #endregion

    #region Monobehaviour

    private void OnEnable()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess += OnBuyProductSuccess;
        HMSIAPManager.Instance.OnInitializeIAPSuccess += OnInitializeIAPSuccess;
        HMSIAPManager.Instance.OnInitializeIAPFailure += OnInitializeIAPFailure;
        HMSIAPManager.Instance.OnBuyProductFailure += OnBuyProductFailure;
    }

    private void OnDisable()
    {
        HMSIAPManager.Instance.OnBuyProductSuccess -= OnBuyProductSuccess;
        HMSIAPManager.Instance.OnInitializeIAPSuccess -= OnInitializeIAPSuccess;
        HMSIAPManager.Instance.OnInitializeIAPFailure -= OnInitializeIAPFailure;
        HMSIAPManager.Instance.OnBuyProductFailure -= OnBuyProductFailure;
    }

    void Awake()
    {
        Singleton();
        InitializeIAP();
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        
    }

    void Start()
    {
        // Uncomment below if InitializeOnStart is not enabled in Huawei > Kit Settings > IAP tab.
        //HMSIAPManager.Instance.InitializeIAP();
    }

    #endregion

    public delegate void PurchaseSuccessEvent();
    public static PurchaseSuccessEvent OnPurchase;
    public void InitializeIAP()
    {
        Debug.Log($"InitializeIAP");

        HMSIAPManager.Instance.InitializeIAP();
    }

    

    public void PurchaseRemoveAds()
    {
        PlayerPrefs.SetInt("REMOVEADS", 1);
        if (OnPurchase != null)
            OnPurchase();

    }

    private void RestoreProducts()
    {

        HMSIAPManager.Instance.RestorePurchaseRecords((restoredProducts) =>
        {
            foreach (var item in restoredProducts.InAppPurchaseDataList)
            {
                if ((IAPProductType)item.Kind == IAPProductType.Consumable)
                {
                    Debug.Log($"Consumable: ProductId {item.ProductId} , SubValid {item.SubValid} , PurchaseToken {item.PurchaseToken} , OrderID  {item.OrderID}");
                    consumablePurchaseRecord.Add(item);
                }
            }
        });

        HMSIAPManager.Instance.RestoreOwnedPurchases((restoredProducts) =>
        {
            foreach (var item in restoredProducts.InAppPurchaseDataList)
            {
                if ((IAPProductType)item.Kind == IAPProductType.Subscription)
                {
                    Debug.Log($"Subscription: ProductId {item.ProductId} , ExpirationDate {item.ExpirationDate} , AutoRenewing {item.AutoRenewing} , PurchaseToken {item.PurchaseToken} , OrderID {item.OrderID}");
                    activeSubscriptions.Add(item);
                }

                else if ((IAPProductType)item.Kind == IAPProductType.NonConsumable)
                {
                    Debug.Log($"NonConsumable: ProductId {item.ProductId} , DaysLasted {item.DaysLasted} , SubValid {item.SubValid} , PurchaseToken {item.PurchaseToken} ,OrderID {item.OrderID}");
                    activeNonConsumables.Add(item);
                }
            }
        });

    }

    public void PurchaseProduct(string productID)
    {
        Debug.Log($"PurchaseProduct");

        HMSIAPManager.Instance.PurchaseProduct(productID);
    }

    #region Callbacks

    private void OnBuyProductSuccess(PurchaseResultInfo obj)
    {
        Debug.Log($"OnBuyProductSuccess");
        PurchaseRemoveAds();

    }

    private void OnInitializeIAPFailure(HMSException obj)
    {
        IAPLog?.Invoke("IAP is not ready.");
    }

    private void OnInitializeIAPSuccess()
    {
        IAPLog?.Invoke("IAP is ready.");

        RestoreProducts();
    }

    private void OnBuyProductFailure(int code)
    {
        IAPLog?.Invoke("Purchase Fail.");
    }

    #endregion
}