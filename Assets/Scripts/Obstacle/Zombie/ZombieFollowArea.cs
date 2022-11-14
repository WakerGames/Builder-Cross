using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollowArea : MonoBehaviour
{
    private FollowingZombie _zombie;

    private void OnEnable()
    {
        _zombie = this.transform.GetComponentInParent<FollowingZombie>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _zombie.characterAnimatorController.PlayRun();
            _zombie.transform.LookAt(_zombie.target);
            //_zombie.transform.Rotate(_zombie.x, _zombie.y, _zombie.z);
            _zombie.transform.position = Vector3.MoveTowards(_zombie.transform.position, _zombie.target.position, _zombie.characterMoveSpeed);
        }
    }
}
