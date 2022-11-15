using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerFollowArea : MonoBehaviour
{
    private FollowingAttacker _attacker;

    private void OnEnable()
    {
        _attacker = transform.GetComponentInParent<FollowingAttacker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _attacker.target = other.transform;
            _attacker.GetComponent<AttackerMovement>().enabled = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
