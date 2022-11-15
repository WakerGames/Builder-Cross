using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player _player;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
    }

    private void Move()
    {
        //_moveVector = Vector3.zero;
        _player._moveVector.x = _player._joystick.Horizontal * _player.characterMoveSpeed * Time.deltaTime;
        _player._moveVector.z = _player._joystick.Vertical * _player.characterMoveSpeed * Time.deltaTime;

        if (_player._joystick.Horizontal != 0 || _player._joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _player._moveVector, _player.characterRotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            if (_player._boxManager.GetHaveBox())
            {
                _player.characterAnimatorController.BoxRun();
            }
            else
            {
                if (_player.StandingOnStickyLiquid)
                    _player.characterAnimatorController.SlimeWalk();
                else
                {
                    _player.characterAnimatorController.PlayRun();
                }
            }
        }
        else if (_player._joystick.Horizontal == 0 && _player._joystick.Vertical == 0)
        {
            if (_player._boxManager.GetHaveBox())
            {
                _player.characterAnimatorController.BoxStand();
            }
            else
            {
                _player.characterAnimatorController.PlayIdle();
            }
        }
        _player.characterRigidbody.MovePosition(_player.characterRigidbody.position + _player._moveVector);
    }

    private void FixedUpdate()
    {
        if (_player.CanMove)
        {
            Move();
        }
    }
}