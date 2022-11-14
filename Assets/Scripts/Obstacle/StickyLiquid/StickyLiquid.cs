using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickyLiquid : MonoBehaviour
{
    private bool _stickyplace = false;
    private void OnTriggerEnter(Collider other)      //To be improved after attackers and zombies are done. Should be merged with player's movement speed
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>()._stickyLiquid = this;
            other.gameObject.GetComponent<PlayerMovement>()._moveSpeed /= 4;
            other.gameObject.GetComponent<PlayerMovement>()._rotateSpeed /= 4;
            isSticky();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>()._stickyLiquid = null;
            other.gameObject.GetComponent<PlayerMovement>()._moveSpeed *= 4;
            other.gameObject.GetComponent<PlayerMovement>()._rotateSpeed *= 4;
            noSticky();
        }
    }
    public bool isSticky()
    {
        _stickyplace = true;
        return _stickyplace;
    }

    public bool noSticky() 
    {
        _stickyplace = false;
        return _stickyplace;        
    }
}
