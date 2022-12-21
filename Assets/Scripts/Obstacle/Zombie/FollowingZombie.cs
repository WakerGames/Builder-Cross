using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class FollowingZombie : Character
{
    [SerializeField] internal BoxCollider followArea;

    [SerializeField] private AudioClip biteSFX;
    
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
            GetComponent<ZombieMovement>().enabled = false;

            characterAnimatorController.ZombieAttack();
            collision.gameObject.GetComponent<Player>().GetBitten(this.transform);

            charAudioSource.clip = biteSFX;
            charAudioSource.Play();
        }
    }

    private void BitePlayer()   // Called in animation event
    {
        var player = GetComponent<ZombieMovement>().GetPlayer();
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