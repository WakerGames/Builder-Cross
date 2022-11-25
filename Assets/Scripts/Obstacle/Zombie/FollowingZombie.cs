using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class FollowingZombie : Character
{
    [SerializeField] internal Transform target;
    //[SerializeField] internal Animator characterAnimatorController;
    [SerializeField] internal BoxCollider followArea;
    //[SerializeField] internal float characterMoveSpeed;

    [SerializeField] internal int x;
    [SerializeField] internal int y;
    [SerializeField] internal int z;

    private void OnEnable()
    {
        CanMove = true;
    }

    private void Start()
    {

        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }


   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Death>().Die(true, DeathCause.Regular, null, null);
            GetComponent<ZombieMovement>().enabled = false;
            
            GetComponent<AnimatorController>().ZombieIdle();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        characterAnimatorController.Play("Zombie Running");
    //        transform.LookAt(target);
    //        transform.Rotate(x, y, z);
    //        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.02f);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        characterAnimatorController.Play("Zombie Idle");

    //    }
    //}


}
