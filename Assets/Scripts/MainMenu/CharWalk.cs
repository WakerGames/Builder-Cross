using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWalk : MonoBehaviour
{
    public float speed = 5f;
    bool _walkTime = false;
    private void Update()
    {
        if (_walkTime)
        {
            transform.Translate(Vector3.forward * (speed) * Time.deltaTime);
        }
    }

    public void WalkBit()
    {
        _walkTime = true;
    }
}
