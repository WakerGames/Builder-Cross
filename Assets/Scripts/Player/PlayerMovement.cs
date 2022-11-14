using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : Character
{
    [SerializeField] private FloatingJoystick _joystick;
    //[SerializeField] private AnimatorController _animatorController;
    //public float characterMoveSpeed;
    //public float _rotateSpeed;
    [SerializeField] private BoxManager _boxManager;
    


    //private Rigidbody characterRigidbody;
    private Vector3 _moveVector;
    

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        CanMove = true;
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
    }

    private void Move()
    {
        //_moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * characterMoveSpeed * Time.deltaTime;
        _moveVector.z = _joystick.Vertical * characterMoveSpeed * Time.deltaTime;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, characterRotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            if (_boxManager.GetHaveBox())
            {
                characterAnimatorController.BoxRun();
                characterMoveSpeed = 5;
            }
            else
            {
                characterAnimatorController.PlayRun();
            }
        }

        else if (_joystick.Horizontal == 0 && _joystick.Vertical == 0)
        {
            if (_boxManager.GetHaveBox())
            {
                characterAnimatorController.BoxStand();
            }
            else
            {
                characterAnimatorController.PlayIdle();
            }

        }
        characterRigidbody.MovePosition(characterRigidbody.position + _moveVector);
    }
}
