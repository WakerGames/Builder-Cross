using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingZombie : MonoBehaviour
{
    [SerializeField] internal Transform target;
    [SerializeField] internal Animator zombieAnimator;
    [SerializeField] internal BoxCollider followArea;
    [SerializeField] internal float zombieMoveSpeed;


    [SerializeField] internal int x;
    [SerializeField] internal int y;
    [SerializeField] internal int z;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Death>().Die();
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        zombieAnimator.Play("Zombie Running");
    //        transform.LookAt(target);
    //        transform.Rotate(x, y, z);
    //        transform.position = Vector3.MoveTowards(transform.position, target.position, 0.02f);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        zombieAnimator.Play("Zombie Idle");

    //    }
    //}


}
