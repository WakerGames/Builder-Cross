using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float timeUntilActivation;

    private float _timer = 0;

    public void DealDamage(Collider other)
    {
        other.gameObject.GetComponent<Death>().Die();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _timer += Time.deltaTime;

            if (_timer >= timeUntilActivation)
            {
                DealDamage(other);
                _timer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _timer = 0;
    }
}