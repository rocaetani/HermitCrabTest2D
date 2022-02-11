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
    public float TimeKeepsRunning;
    public float _speed;

    private Jump _jump;
    
    private Animator _animator;

    
    public bool IsRunning;

    public bool StopMoving;

    private float _timeTillStopRunning;
    
    


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
            float timeLeftRunning = _timeTillStopRunning - Time.time;
            if (timeLeftRunning > 0)
            {
                _speed = (WalkSpeed + (timeLeftRunning/TimeKeepsRunning) * (RunSpeed - WalkSpeed));
            }
            else
            {
                _speed = WalkSpeed;
            }


            IsRunning = false;
            if (InputController.Instance.Run() && _jump.IsGrounded)
            {
                _speed = RunSpeed;
                IsRunning = true;
                _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Run);
                _timeTillStopRunning = Time.time + TimeKeepsRunning;
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