using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Untagged")
        {
            Destroy(collision.gameObject, 1f);
        }
    }

}
