
using UnityEngine;

public class AttackerMovement : MonoBehaviour
{
    private AnimatorController characterAnimatorController;
    private Transform target;
    private float characterMoveSpeed;
    private Character _character;
    
    private void OnEnable()
    {
        
        _character = GetComponent<Character>();
        _character.charAudioSource.Play();
        characterAnimatorController = GetComponent<AnimatorController>();
        target = gameObject.GetComponent<FollowingAttacker>().target;
        characterMoveSpeed = gameObject.GetComponent<FollowingAttacker>().characterMoveSpeed;
        
    }

    void FixedUpdate()
    {
        if (_character.StandingOnStickyLiquid)
        {
            characterAnimatorController.SlimeWalk();
        }
        else
        {
            characterAnimatorController.AttackerRun();

        }
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _character.characterMoveSpeed);
    }
}
