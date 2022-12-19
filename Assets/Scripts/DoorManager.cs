using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public Transform target;
    bool _doorOpen = false;

    // The angle to rotate the door by
    public float rotateAngle = 90f;

    // The axis to rotate the door around
    public Vector3 rotateAxis = Vector3.up;

    // The speed at which to rotate the door
    public float rotateSpeed = 1f;

    // The target rotation for the door
    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        if (_doorOpen)
        {

            // Calculate the target rotation for the door
            targetRotation = transform.rotation * Quaternion.AngleAxis(rotateAngle, rotateAxis);

            // Rotate the door towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
            
        }
    }
    void RotateDoor()
    {
        transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }
    public void MakeDoorOpen()
    {
        _doorOpen = true;
    }
}
