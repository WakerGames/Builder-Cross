using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float characterMoveSpeed;
    public float characterRotateSpeed;
    public AnimatorController characterAnimatorController;
    public Rigidbody characterRigidbody;
    public bool CanMove { get; set; }
    public RagdollManager characterRagdollManager;
    public Death characterDeath;
    public bool StandingOnStickyLiquid { get; set; }
}
