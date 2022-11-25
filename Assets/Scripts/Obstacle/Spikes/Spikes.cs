using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class Spikes : MonoBehaviour, IDamageDealer
{
  

    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Regular, null, null);
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    _timer += Time.deltaTime;

    //    if (_timer >= timeUntilActivation)
    //    {
    //        DealDamage(collision.gameObject);
    //        _timer = 0;
    //    }
    //}
   
    
    //private void OnCollisionExit(Collision collision)
    //{
    //    _timer = 0;
    //}

    private void OnTriggerEnter(Collider other)
    {
       

        
            DealDamage(other.gameObject);
            
        
    }

    
}