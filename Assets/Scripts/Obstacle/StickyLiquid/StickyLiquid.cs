using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyLiquid : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)      //To be improved after attackers and zombies are done. Should be merged with player's movement speed
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().characterMoveSpeed /= 4;
            other.gameObject.GetComponent<PlayerMovement>().characterRotateSpeed /= 4;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().characterMoveSpeed *= 4;
            other.gameObject.GetComponent<PlayerMovement>().characterRotateSpeed *= 4;
        }
    }
}
