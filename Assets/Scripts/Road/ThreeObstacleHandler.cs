using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThreeObstacleHandler : MonoBehaviour
{
    

    private void Spawn()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case 1:
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                transform.GetChild(2).gameObject.SetActive(true);
                break;
        }
    }
    void Start()
    {
        Spawn();
    }
}