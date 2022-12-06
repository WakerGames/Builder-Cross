using Cinemachine;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

[RequireComponent(typeof(Rigidbody))]
public class Player : Character
{
    [SerializeField] internal FloatingJoystick _joystick;
    //[SerializeField] private AnimatorController _animatorController;
    //public float characterMoveSpeed;
    //public float _rotateSpeed;
    [SerializeField] internal BoxManager _boxManager;


    public delegate void OnPlayerDead();

    public static OnPlayerDead playerDied;

   


    //private Rigidbody characterRigidbody;
    
    

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerDied += characterDeath.SlowTime;
        playerDied += StopCamera;
        Debug.Log("Baþlama");
    }

    private void OnDisable()
    {
        Debug.Log("Ölüm Kýsmý");
        playerDied -= characterDeath.SlowTime;
        playerDied -= StopCamera;
        
    }

    private void StopCamera()
    {
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = null;
        GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = null;
    }

    private void Start()
    {
        CanMove = true;
    }


    //private void Move()
    //{
    //    //_moveVector = Vector3.zero;
    //    _moveVector.x = _joystick.Horizontal * characterMoveSpeed * Time.deltaTime;
    //    _moveVector.z = _joystick.Vertical * characterMoveSpeed * Time.deltaTime;

    //    if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
    //    {
    //        Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, characterRotateSpeed * Time.deltaTime, 0.0f);
    //        transform.rotation = Quaternion.LookRotation(direction);

    //        if (_boxManager.GetHaveBox())
    //        {
    //            characterAnimatorController.BoxRun();
    //            characterMoveSpeed = 5;
    //        }
    //        else
    //        {
    //            characterAnimatorController.PlayRun();
    //        }
    //    }

    //    else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
    //    {
    //        if (_boxManager.GetHaveBox())
    //        {
    //            characterAnimatorController.BoxStand();
    //        }
    //        else
    //        {
    //            characterAnimatorController.PlayIdle();
    //        }

    //    }
    //    characterRigidbody.MovePosition(characterRigidbody.position + _moveVector);
    //}
    
}
