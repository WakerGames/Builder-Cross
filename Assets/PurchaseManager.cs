using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;



public class PurchaseManager : MonoBehaviour,IDetailedStoreListener
{
    [SerializeField] Button removeAdsButton;
    private IStoreController controller;
    private IExtensionProvider extensions;
    public string environment = "production";

    private static PurchaseManager _instance;

    public static PurchaseManager Instance { get { return _instance; } }

    public delegate void PurchaseSuccessEvent();
    public static PurchaseSuccessEvent OnPurchase;

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
    public void StartIAP()
    {


        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("remove_ads", ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }


    async void Start()
    {
        try
        {
            var options = new InitializationOptions()
                .SetEnvironmentName(environment);

            await UnityServices.InitializeAsync(options);
        }
        catch (Exception exception)
        {
            // An error occurred during services initialization.
        }
        StartIAP();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
    }

    void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
    {

    }

    void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {

    }

    PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if (purchaseEvent.purchasedProduct.definition.id == "remove_ads")
        {
            Debug.Log("here");
            PurchaseRemoveAds();
        }
        //SendPurchaseInfo();
        return PurchaseProcessingResult.Complete;

    }
    public void RemoveAdsCompleted()
    {
        controller.InitiatePurchase("remove_ads");
    }
    public void RestorePurchases()
    {
        

        if (Application.platform == RuntimePlatform.IPhonePlayer)
            
        {
            //Debug.Log("RestorePurchases started ...");

            var apple = extensions.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result,callback) =>
            {
                PurchaseRemoveAds();
                //Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
                
            });
        }
        else
        {
            //Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }
    public void PurchaseRemoveAds()
    {
        PlayerPrefs.SetInt("REMOVEADS", 1);
        if (OnPurchase != null)
            OnPurchase();

    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
    }
}
