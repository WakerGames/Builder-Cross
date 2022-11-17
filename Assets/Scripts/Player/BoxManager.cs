using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public GameObject[] BoxArray;
    private bool _hasBox;
    private int _countBox = 1;
    [SerializeField] private GameObject boxPlace;
    [SerializeField] private GameObject _currentBox;



    public List<GameObject> BoxesOnHand = new List<GameObject>();


    private void Start()
    {
        foreach (var collectible in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            collectible.GetComponent<BoxMovementAnimation>()._boxManager = this;

        }
    }

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
            
            SetChild(other.gameObject);
            BoxesOnHand.Add(other.gameObject);
            _countBox++;
            GetComponent<Player>().characterMoveSpeed -= 1f;
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
}