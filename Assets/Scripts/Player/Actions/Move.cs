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
    private float _speed;

    public bool IsRunning;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _speed = InputController.Instance.Run() ? RunSpeed : WalkSpeed;
        IsRunning = InputController.Instance.Run();
    }
    
    private void FixedUpdate()
    {
        MoveUpdate();
    }

    private void MoveUpdate()
    {
        Vector2 position = (_speed * Time.deltaTime * transform.right);

        _rigidbody.velocity = new Vector2(position.x, _rigidbody.velocity.y);;
    }
    
}