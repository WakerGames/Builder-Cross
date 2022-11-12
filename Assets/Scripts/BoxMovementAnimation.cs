using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovementAnimation : MonoBehaviour
{
    public BoxManager _boxManager;
    private void FixedUpdate()
    {
        if (_boxManager.BoxesOnHand.Contains(this.gameObject))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {

            transform.RotateAround(transform.position, Vector3.up, 100 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.PingPong(Time.time * 0.05f, 0.04f) - 0.02f), transform.position.z);
        }




    }
}
