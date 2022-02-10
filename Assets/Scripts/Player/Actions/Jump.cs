using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Thrust;
    
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;
    private bool _shouldJump;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isGrounded = true;
        _shouldJump = false;
    }

    private void Update()
    {
        if (InputController.Instance.Jump())
        {
            _shouldJump = true;
        }
    }

    private void FixedUpdate()
    {
        if (_shouldJump & _isGrounded)
        {
            _isGrounded = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(transform.up * Thrust, ForceMode2D.Impulse);
        }

        _shouldJump = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        _isGrounded = true;
    }
    
}