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
    [SerializeField] private TimerManager _timerManager;

    public delegate void OnPlayerDead();

    public static OnPlayerDead playerDied;


    //private Rigidbody characterRigidbody;
    internal Vector3 _moveVector;
    

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerDied += characterDeath.SlowTime;
    }

    private void OnDisable()
    {
        playerDied -= characterDeath.SlowTime;
    }

    private void Start()
    {
        CanMove = true;
    }

    private void FixedUpdate()
    {
        if (_timerManager.isTimeEnd())
        {
            characterRagdollManager.RagdollModeOn(DeathCause.Regular, null, null);
        }
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
