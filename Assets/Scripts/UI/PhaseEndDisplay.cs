using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PhaseEndDisplay : MonoBehaviour
{
    
    private GameManager _gameManager;

    public Text TimeText;

    public Text ScoreText;

    public Text DeathText;

    private void Start()
    {
        _gameManager = GameManager.Instance;
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