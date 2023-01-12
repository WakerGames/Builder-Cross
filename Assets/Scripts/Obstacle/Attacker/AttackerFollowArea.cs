using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerFollowArea : MonoBehaviour
{
    private AttackerMovement _attackerMovement;

    private void OnEnable()
    {
        _attackerMovement = transform.GetComponentInParent<AttackerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _attackerMovement.SetPlayer(other.transform);
            _attackerMovement.enabled = true;
            GetComponent<Collider>().enabled = false;

        }
    }
}
