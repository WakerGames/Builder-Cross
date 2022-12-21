using Cinemachine;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class Player : Character
{
    [SerializeField] public FloatingJoystick _joystick;
    [SerializeField] public GameObject _deadScene;

    [SerializeField] public GameObject _gamehud;

    //public float characterMoveSpeed;
    //public float _rotateSpeed;
    [SerializeField] internal BoxManager _boxManager;

    public delegate void OnPlayerDead();

    public static OnPlayerDead playerDied;


    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        playerDied += characterDeath.SlowTime;
        playerDied += StopCamera;
    }

    private void OnDisable()
    {
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

    public void GetBitten(Transform zombieTransform)
    {
        GetComponent<Character>().CanMove = false;
        this.transform.parent = zombieTransform;
        transform.localRotation = Quaternion.identity;
        Debug.Log(transform.localPosition);
        Vector3 newPosition = new Vector3(transform.localPosition.x + 0.05f, transform.localPosition.y, transform.localPosition.z + 0.25f);
        transform.localPosition = newPosition;
        characterAnimatorController.PlayIdle();
    }
}