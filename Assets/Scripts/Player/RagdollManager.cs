using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RagdollManager : MonoBehaviour
{
    public BoxCollider mainCollider;
    public GameObject mainRig;
    public Animator mainAnimator;
    private PlayerMovement _playerMovement;
    [SerializeField] private TimerManager _timerEnd;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();


        GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
        GetComponent<Rigidbody>().inertiaTensorRotation = Quaternion.identity;
    }

    void Update()
    {
        if (_timerEnd.isTimeEnd())
        {
            RagdollModeOn();
        }
    }

    Collider[] ragDollColliders;
    Rigidbody[] limbsRigidbodies;

    void GetRagdollBits()
    {
        ragDollColliders = mainRig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = mainRig.GetComponentsInChildren<Rigidbody>();
    }


    //Get death type with enum

    public void RagdollModeOn()
    {
        _playerMovement.CanMove = false;
        mainAnimator.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void RagdollsExplosionModeOn(float horizontalForceRadius, float verticalForceAmount)
    {
        _playerMovement.CanMove = false;
        mainAnimator.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
            rigid.AddForce(transform.right * Random.Range(-horizontalForceRadius, horizontalForceRadius) +
                           transform.up * verticalForceAmount +
                           transform.forward * Random.Range(-horizontalForceRadius, horizontalForceRadius),
                ForceMode.Impulse);
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    public void RagdollsMachineGunModeOn(float horizontalForceRadius)
    {
        _playerMovement.CanMove = false;
        mainAnimator.enabled = false;

        foreach (Collider col in ragDollColliders)
        {
            col.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = false;
            rigid.AddForce(new Vector3(transform.position.x * horizontalForceRadius,0f,0f), ForceMode.Impulse);



        }
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void RagdollModeOff()
    {
        foreach (Collider col in ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rigid in limbsRigidbodies)
        {
            rigid.isKinematic = true;
        }

        mainAnimator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}