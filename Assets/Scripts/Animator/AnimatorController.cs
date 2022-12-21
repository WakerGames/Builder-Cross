using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorController : MonoBehaviour
{
    [SerializeField] private Animator _animator;



    public void PlayIdle()
    {
        _animator.Play("Idle 0");
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

    public void PlayerBitten()
    {
        _animator.Play("Player Bitten");
    }

    public void PlayerAxed()
    {
        _animator.Play("Player Axed");
    }

    public void ZombieRun()
    {
        _animator.Play("Zombie Running");
    }
    public void AttackerRun()
    {
        _animator.Play("Attacker Running");
    }

    public void AttackerAttack()
    {
        _animator.Play("Attacker Attack");
    }

    public void SlimeWalk()
    {
        _animator.Play("SlimeWalk");
    }
    public void AttackerIdle()
    {
        _animator.Play("Attacker Idle");
    }
    public void ZombieIdle()
    {
        _animator.Play("Zombie Idle");
    }
    public void WalkMain()
    {
        _animator.Play("JustWalk");
    }
    public void ZombieAttack()
    {
        _animator.Play("Zombie Attack");
    }
    
}
