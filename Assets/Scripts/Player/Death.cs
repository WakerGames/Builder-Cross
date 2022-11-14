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
        _ragdollManager = GetComponent<RagdollManager>();
    }

    private void OnEnable()
    {
        BoxManager.playerDiedBox += SlowTime;
    }
    
    private void OnDisable()
    {
        BoxManager.playerDiedBox -= SlowTime;
    }

    private void SlowTime()
    {
        Time.timeScale = 0.1f;
    }

    public void Die()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        
        if (BoxManager.playerDiedBox != null)
            BoxManager.playerDiedBox();

        _ragdollManager.RagdollModeOn(DeathCause.Regular, null, null);
    }

    public void Explode(float horizontalForceRadius, float verticalForceAmount)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        
        if (BoxManager.playerDiedBox != null)
            BoxManager.playerDiedBox();

        _ragdollManager.RagdollModeOn(DeathCause.Explosion, horizontalForceRadius, verticalForceAmount);
    }
    public void GotShot(float horizontalForceRadius)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        if (BoxManager.playerDiedBox != null)
            BoxManager.playerDiedBox();

        _ragdollManager.RagdollModeOn(DeathCause.Turret, horizontalForceRadius, null);
    }
}