using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {

    }

    public void PlayIdle()
    {
        _animator.Play("Breathing Idle 0");
    }

    public void PlayRun()
    {
        _animator.Play("Running");
    }
    public void BoxRun()
    {
        _animator.Play("BoxRun");

    }
    public void BoxStand()
    {
        _animator.Play("Carrying");
    }
    public void ZombieRun()
    {
        _animator.Play("Zombie Running");
    }
    public void AttackerRun()
    {
        _animator.Play("Attacker Running");
    }
    public void SlimeWalk()
    {
        _animator.Play("SlimeWalk");
    }

}
