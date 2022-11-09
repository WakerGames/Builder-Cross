using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour, IDamageDealer
{
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
