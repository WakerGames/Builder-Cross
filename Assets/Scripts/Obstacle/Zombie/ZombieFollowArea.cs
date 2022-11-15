using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowArea : MonoBehaviour
{
    private FollowingZombie _zombie;

    private void OnEnable()
    {
        _zombie = transform.GetComponentInParent<FollowingZombie>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _zombie.target = other.transform;
            _zombie.GetComponent<ZombieMovement>().enabled = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
