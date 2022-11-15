using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    private AnimatorController characterAnimatorController;
    private Transform target;
    private float characterMoveSpeed;

    private void OnEnable()
    {
        characterAnimatorController = GetComponent<AnimatorController>();
        target = gameObject.GetComponent<FollowingZombie>().target;
        characterMoveSpeed = gameObject.GetComponent<FollowingZombie>().characterMoveSpeed;
    }

    void FixedUpdate()
    {
        characterAnimatorController.ZombieRun();
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, characterMoveSpeed);
    }
}
