using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBlade : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int spinningSpeed;
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0,spinningSpeed,0);
    }

    public void DealDamage(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Death>().Die();
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        DealDamage(other);
    }
}
