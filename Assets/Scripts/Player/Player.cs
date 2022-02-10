using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Life { get; private set; }


    private GameManager _gameManager;
    public PlayerDisplay PlayerDisplay;
    

    private void Start()
    {
        Life = 3;
        PlayerDisplay.StartFilledLife();
        
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        PlayerDisplay.SetScore(GetScore());
    }

    public void ReduceLife()
    {
        Life -= 1;
        PlayerDisplay.EmptyLife();
        if (Life == 0)
        {
            _gameManager.EndPhase(false);
        }
        else
        {
            _gameManager.RestartPhase(transform.position);
        }
    }

    public int GetScore()
    {
        return (int) transform.position.x;
    }
}