using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOverDisplay : MonoBehaviour
{
    
    private GameManager _gameManager;

    public Text Title;
    
    public Text TimeText;

    public Text ScoreText;

    public Text DeathText;

    public GameObject ReturnToCheckpoint;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        
        if (_gameManager.PlayerSucceed)
        {
            Title.text = "Success";
            ReturnToCheckpoint.SetActive(false);
        }
        else
        {
            Title.text = "Game Over";
            ReturnToCheckpoint.SetActive(true);
        }


        PopulateValues();

    }

    private void PopulateValues()
    {
        UpdateTimeTookOnPhase();
        UpdateScore();
        UpdateDeath();
    }

    private void UpdateTimeTookOnPhase()
    {
        TimeText.text = TimeFormatter.Format((int) _gameManager.TimeTookOnPhase);
    }
    
    private void UpdateScore()
    {
        ScoreText.text = _gameManager.FurthestPosition + "m";
    }

    private void UpdateDeath()
    {
        DeathText.text = _gameManager.PointsOfDeath.Count + "";
    }

}