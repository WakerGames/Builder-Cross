using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRandomizer : MonoBehaviour
{
    [SerializeField, Range(0, 40)] private int spikesToDisable;

    void Start()
    {
        for (int i = 0; i < spikesToDisable; i++)
        {
            this.gameObject.transform.GetChild(Random.Range(0, this.gameObject.transform.childCount)).gameObject.SetActive(false);
        }
    }
}
