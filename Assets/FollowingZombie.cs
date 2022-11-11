using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingZombie : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Animator zombieAnimator;
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int z;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombieAnimator.Play("Zombie Running");
            transform.LookAt(target);
            transform.Rotate(x, y, z);
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.02f);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            zombieAnimator.Play("Zombie Idle");

        }
    }


}
