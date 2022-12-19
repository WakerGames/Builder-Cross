using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class FollowingZombie : Character
{

    //[SerializeField] internal Animator characterAnimatorController;
    [SerializeField] internal BoxCollider followArea;
    //[SerializeField] internal float characterMoveSpeed;
    

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
            
            GetComponent<ZombieMovement>().enabled = false;

            GetComponent<AnimatorController>().ZombieAttack();

            collision.gameObject.GetComponent<Character>().CanMove = false;
            collision.gameObject.transform.parent = this.transform;
          
            collision.gameObject.GetComponent<AnimatorController>().PlayIdle();
        }
    }

    public void BitePlayer()
    {
        var player = GetComponent<ZombieMovement>().target.gameObject;
        player.GetComponent<Death>().Die(true, DeathCause.Regular, null, null);
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