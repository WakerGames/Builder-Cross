using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class StickyLiquid : MonoBehaviour
{
       
    private void OnTriggerEnter(Collider other)      //To be improved after attackers and zombies are done. Should be merged with player's movement speed
    {
        if (other.GetComponent<Character>() != null)
        {
            other.GetComponent<Character>().characterMoveSpeed /= 4;
            other.GetComponent<Character>().characterRotateSpeed /= 4;
            other.GetComponent<Character>().StandingOnStickyLiquid = true;
          
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            other.GetComponent<Character>().characterMoveSpeed *= 4;
            other.GetComponent<Character>().characterRotateSpeed *= 4;
            other.GetComponent<Character>().StandingOnStickyLiquid = false;
            
        }
    }
   
   
    
}
