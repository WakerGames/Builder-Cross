using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSpinMaker : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Transform>().Rotate(0, 10, 0);
        Quaternion.Euler(0, 0, 45);
    }
}