using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _joystick;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private float _movementSpeed;

    private void FixedUpdate()
    {
        _playerRigidbody.velocity = new Vector3(_joystick.Horizontal * _movementSpeed, _playerRigidbody.velocity.y, _joystick.Vertical * _movementSpeed);

        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_playerRigidbody.velocity);
            _playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            _playerAnimator.SetBool("isRunning", false);
        }
    }
}
