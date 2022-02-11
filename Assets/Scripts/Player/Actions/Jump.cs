using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Thrust;
    
    private Rigidbody2D _rigidbody;
    public bool IsGrounded;
    private bool _shouldJump;

    private Animator _animator;

    public bool StopJump;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        IsGrounded = true;
        _shouldJump = false;
        _animator = GetComponent<Animator>();
        StopJump = false;
    }

    private void Update()
    {
        if (!StopJump)
        {
            if (InputController.Instance.Jump())
            {
                _shouldJump = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (!StopJump)
        {
            if (_shouldJump & IsGrounded)
            {
                IsGrounded = false;
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.AddForce(transform.up * Thrust, ForceMode2D.Impulse);
                _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Jump);
            }

            if (_rigidbody.velocity.y < 0)
            {
                _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Fall);
            }

            _shouldJump = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        IsGrounded = true;
    }
    
    


}