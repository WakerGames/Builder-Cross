using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerMovement : MonoBehaviour
{
    private AnimatorController characterAnimatorController;
    private Transform target;
    private float characterMoveSpeed;

    private void OnEnable()
    {
        characterAnimatorController = GetComponent<AnimatorController>();
        target = gameObject.GetComponent<FollowingAttacker>().target;
        characterMoveSpeed = gameObject.GetComponent<FollowingAttacker>().characterMoveSpeed;
    }

    void FixedUpdate()
    {
        characterAnimatorController.AttackerRun();
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, characterMoveSpeed);
    }
}
