using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class SpinningBlade : MonoBehaviour, IDamageDealer
{
    [SerializeField] private int spinningSpeed;


    void FixedUpdate()
    {
        gameObject.transform.Rotate(0,spinningSpeed,0);
    }

    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>().Die(other.TryGetComponent(out Player temp), DeathCause.Regular, null, null);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    DealDamage(collision.gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
}
