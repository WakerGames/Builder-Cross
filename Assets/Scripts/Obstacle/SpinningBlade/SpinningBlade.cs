using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class SpinningBlade : MonoBehaviour, IDamageDealer
{
    public Transform target;
    public float rotateSpeed = 2f;

    private void Awake()
    {
       // FindObjectOfType<AudioManager>().Play("SpinningBlade");
    }
    void Update()
    {
        
        transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);

    }

    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>().Die(other.TryGetComponent(out Player temp), DeathCause.Regular, null, null);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    DealDamage(collision.gameObject);
    //}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Character>() != null)
        {
            DealDamage(other.gameObject);
        }
    }
}
