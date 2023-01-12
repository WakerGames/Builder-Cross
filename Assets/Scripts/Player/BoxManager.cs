using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class BoxManager : MonoBehaviour
{
    [SerializeField] private float boxSlowAmount;
    public GameObject[] BoxArray;
    private bool _hasBox;
    private int _countBox = 1;
    [SerializeField] private GameObject boxPlace;
    [SerializeField] private GameObject _currentBox;
    public GameObject[] BoxUI;
    private int index = 0;
    [SerializeField] AudioSource _boxSound;
    public CinemachineVirtualCamera _mainCamera;
    public bool _fovCam = false;
    public static BoxManager Instance { get; set; }

    public List<GameObject> BoxesOnHand = new List<GameObject>();
    [SerializeField] private SettingsSO settings;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    //private void Update()
    //{
    //    if (_fovCam)
    //    {
    //        Debug.Log("_fovcam");
    //        _mainCamera.m_Lens.FieldOfView = Mathf.Lerp(120, 110, 0.1f);
    //        if (_mainCamera.m_Lens.FieldOfView == 110)
    //        {
    //            _fovCam = false;
    //            Debug.Log("_fovcam false");
    //        }
    //    }
    //}

    private void OnEnable()
    {
        if (this.gameObject.CompareTag("Player"))
            Player.playerDied += UnSetChild;
    }

    private void OnDisable()
    {
        if (this.gameObject.CompareTag("Player"))
            Player.playerDied -= UnSetChild;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            _currentBox = other.gameObject;
            _hasBox = true;
            //StartCoroutine(BoostCamera());

            SetChild(other.gameObject);
            _countBox++;
            BoxesOnHand.Add(other.gameObject);


            if (settings.vibrationEnabled)
            {
                Handheld.Vibrate();
            }

            GetComponent<Player>().characterMoveSpeed -= boxSlowAmount;
        }
    }

    public void UnSetChild()
    {
        if (_hasBox)
        {
            for (int i = 0; i < BoxesOnHand.Count; i++)
            {

                BoxesOnHand[i].AddComponent<Rigidbody>();
                BoxesOnHand[i].GetComponent<BoxCollider>().isTrigger = false;
                BoxesOnHand[i].GetComponent<Rigidbody>().useGravity = true;
                BoxesOnHand[i].transform.parent = null;
            }

        }
    }

    void SetChild(GameObject collectable)
    {
        _boxSound.Play();


        BoxUI[index].SetActive(true);


        index++;


        collectable.transform.parent = boxPlace.transform;
        collectable.transform.localPosition = new Vector3(0, 0, 0);
        if (_countBox == 2)
        {

            collectable.transform.localPosition = new Vector3(0, 0.5f, 0);
        }

        if (_countBox == 3)
        {
            collectable.transform.localPosition = new Vector3(0, 1.01f, 0);
        }
    }

    public bool GetHaveBox()
    {
        return _hasBox;

    }

    //IEnumerator BoostCamera()
    //{
    //    _mainCamera.m_Lens.FieldOfView = 120;
    //    _fovCam = true;
    //    yield return new WaitForSeconds(0f);
    //    //_mainCamera.m_Lens.FieldOfView = 110;
    //}
}