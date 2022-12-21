using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class FollowingAttacker : Character
{
    [SerializeField] internal BoxCollider followArea;
    [SerializeField] private AudioClip attackSFX;
    //[SerializeField] internal float characterMoveSpeed;

    private void OnEnable()
    {
        CanMove = true;
    }

    private void Start()
    {
        characterRigidbody.centerOfMass = Vector3.zero;
        characterRigidbody.inertiaTensorRotation = Quaternion.identity;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            GetComponent<AttackerMovement>().enabled = false;
            
            characterAnimatorController.AttackerAttack();
            player.GetComponent<Player>().GetKilled(this.transform, 0f, 0f, player.GetComponent<AnimatorController>().PlayerAxed);
            
            followArea.enabled = false;

            
        }
    }


    private void AxeSound()     // Called in animation event
    {
        charAudioSource.clip = attackSFX;
        charAudioSource.Play();
    }

    private void AxePlayer()    // Called in animation event
    {
        var player = GetComponent<AttackerMovement>().GetPlayer().gameObject;
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