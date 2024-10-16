using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.8f;
    
    protected CharacterController _characterController;

    private Vector3 _velocity;
    public Vector3 Velocity => _velocity;
    private float _verticalVelocity;
    private Vector3 _movementInput;

    public bool IsGround => _characterController.isGrounded;
    private Quaternion _targetRotation;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    protected void FixedUpdate()
    {
        ApplyGravity();
        ApplyRotation();
        Move();
    }

    private void ApplyRotation()
    {
        float rotateSpeed = 8f;
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, Time.fixedDeltaTime * rotateSpeed);
    }

    private void ApplyGravity()
    {
        if(IsGround && _verticalVelocity <= 0)
        {
            _verticalVelocity = -0.5f;
        }
        else
        {
            _verticalVelocity += _gravity * Time.fixedDeltaTime;
        }
        _velocity.y = _verticalVelocity;
    }

    
    private void Move()
    {
        _characterController.Move(_velocity);
    }

    public void SetMovement(Vector3 movement, bool isRotation = true)
    {
        _velocity = movement * Time.fixedDeltaTime;

        if(_velocity.sqrMagnitude > 0 && isRotation)
        {
            _targetRotation = Quaternion.LookRotation(_velocity);
        }
    }

    public void StopImmediately()
    {
        _velocity = Vector3.zero;
    }

    /*public void GetKnockBack(Vector3 force)
    {
        _agent.HealthCompo.actionData.knockbackPower = force.magnitude;
        

        Vector3 direction = -force;
        direction.y = 0;
        
        _targetRotation = Quaternion.LookRotation(direction.normalized);
        _agent.transform.rotation = _targetRotation;
        
        Player player = _agent as Player;
        player.StateMachine.ChangeState(PlayerStateEnum.Hurt);

    }*/
    
    
}
