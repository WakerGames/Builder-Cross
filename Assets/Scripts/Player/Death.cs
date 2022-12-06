using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Death : MonoBehaviour
{
    [SerializeField] private RagdollManager _ragdollManager;
    [SerializeField] public GameObject _deadScene;
    [SerializeField] private GameObject _joyStick;
    [SerializeField] private GameObject _gamehud;
    public enum DeathCause
    {
        Regular,
        Explosion,
        Turret
    }

    private void Awake()
    {
        _ragdollManager = GetComponent<RagdollManager>();
    }


    public void SlowTime()
    {
        Time.timeScale = 0.1f;
    }


    public void Die(bool playerIsDying, DeathCause causeOfDeath, float? horizontalForceRadius, float? verticalForceAmount)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (playerIsDying && Player.playerDied != null)
        {
            Player.playerDied();
        }
        if(!playerIsDying)
        {
            if(GetComponent<AttackerMovement>() !=null)
                GetComponent<AttackerMovement>().enabled = false;
            if (GetComponent<ZombieMovement>() != null)
                GetComponent<ZombieMovement>().enabled =false;

        }

        switch (causeOfDeath)
        {
            case DeathCause.Regular:
                DeathSceen();
                _ragdollManager.RagdollModeOn(DeathCause.Regular, null, null);
                break;

            case DeathCause.Explosion:
                _ragdollManager.RagdollModeOn(DeathCause.Explosion, horizontalForceRadius, verticalForceAmount);
                break;

            case DeathCause.Turret:
                _ragdollManager.RagdollModeOn(DeathCause.Turret, horizontalForceRadius, null);
                break;

            default:
                break;
        }
    }
    public void DeathSceen()
    {
        _deadScene.SetActive(true);
        _joyStick.SetActive(false);
        _gamehud.SetActive(false);
    }
}