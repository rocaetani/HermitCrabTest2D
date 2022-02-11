using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float WalkSpeed;
    public float RunSpeed;
    public float _speed;

    private Jump _jump;
    
    private Animator _animator;

    
    public bool IsRunning;

    public bool StopMoving;


    private void Start()
    {
        _jump = GetComponent<Jump>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _speed = WalkSpeed;
        StopMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StopMoving)
        {
            _speed = (WalkSpeed + _speed)/2;
            IsRunning = false;
            if (InputController.Instance.Run() && _jump.IsGrounded)
            {
                _speed = RunSpeed;
                IsRunning = true;
                _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Run);
            }
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
    
    private void FixedUpdate()
    {
        if (!StopMoving)
        {
            MoveUpdate();
        }
    }

    private void MoveUpdate()
    {
        Vector2 position = (_speed * Time.deltaTime * transform.right);

        _rigidbody.velocity = new Vector2(position.x, _rigidbody.velocity.y);;
    }
    
}