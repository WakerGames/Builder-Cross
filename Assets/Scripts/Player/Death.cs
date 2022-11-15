using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

public class Death : MonoBehaviour
{
    private RagdollManager _ragdollManager;
    public enum DeathCause
    {
        Regular,
        Explosion,
        Turret
    }

    private void Awake()
    {
        _ragdollManager = GetComponent<Player>()?.characterRagdollManager;
    }


    public void SlowTime()
    {
        Time.timeScale = 0.1f;
    }


    public void Die(bool playerIsDying, DeathCause causeOfDeath, float? horizontalForceRadius, float? verticalForceAmount)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        Debug.Log(playerIsDying);
        if (playerIsDying && Player.playerDied != null)
        {
            Player.playerDied();
        }

        switch (causeOfDeath)
        {
            case DeathCause.Regular:
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
}