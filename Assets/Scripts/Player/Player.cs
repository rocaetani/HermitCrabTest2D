using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Life { get; private set; }


    private GameManager _gameManager;
    public PlayerDisplay PlayerDisplay;

    private Move _move;
    private Jump _jump;

    private Animator _animator;
    
    private bool _lifeAlreadyReduced;

    


    private void Start()
    {
        _move = GetComponent<Move>();
        _jump = GetComponent<Jump>();
        _animator = GetComponent<Animator>();
        
        Life = 3;
        PlayerDisplay.StartFilledLife();

        _lifeAlreadyReduced = false;
        
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        PlayerDisplay.SetScore(GetScore());

        if (!_move.IsRunning && _jump.IsGrounded && !_move.StopMoving)
        {
            _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Walk);
        }
    }

    public void ReduceLife()
    {
        if (!_lifeAlreadyReduced)
        {
            _lifeAlreadyReduced = true;
            Life -= 1;
            PlayerDisplay.EmptyLife();
            if (Life == 0)
            {
                _gameManager.EndPhase(false);
            }
            else
            {
                DisableMovement();
                _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Dead);
                StartCoroutine(nameof(RestartFromCheckpoint), 1.5f );
            }
        }

        
    }

    public int GetScore()
    {
        return (int) transform.position.x;
    }

    private IEnumerator RestartFromCheckpoint(int waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        _gameManager.RestartFromCheckpoint(transform.position);
        _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Idle);
        _animator.SetInteger(TagManager.PLAYER_ANIM_STATE, (int) PlayerState.Blink);
        _lifeAlreadyReduced = false;


    }

    public void EnableMovement()
    {
        _move.StopMoving = false;
        _jump.StopJump = false; 
        
        Debug.Log("Movement Enabled");
    }
    
    public void DisableMovement()
    {
        _move.StopMoving = true;
        _jump.StopJump = true; 
    }
    
    
    
}