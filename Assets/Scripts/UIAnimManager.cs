using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimManager : MonoBehaviour
{
    [SerializeField] Animator myAnimation;
  
    void StopAnim()
    {
        myAnimation.enabled = false;
    }

}
