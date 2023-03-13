
using UnityEngine;

public class AttackerMovement : MonoBehaviour
{
    private AnimatorController characterAnimatorController;
    private Transform target;
    private Character _character;
    
    private void OnEnable()
    {
        _character = GetComponent<Character>();
        _character.charAudioSource.Play();
        _character.characterRigidbody.useGravity = true;
    }

    void FixedUpdate()
    {
        if (_character.StandingOnStickyLiquid)
        {
            _character.characterAnimatorController.SlimeWalk();
        }
        else
        {
            _character.characterAnimatorController.AttackerRun();

        }
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, _character.characterMoveSpeed);
    }

    public Transform GetPlayer()
    {
        return target;
    }

    public void SetPlayer(Transform newTarget)
    {
        target = newTarget;
    }
}
