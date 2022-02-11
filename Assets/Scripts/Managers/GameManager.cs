using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    public Player Player;
    
    private float _timePhaseStart;
    public float TimeTookOnPhase;
    
    public List<Vector2> PointsOfDeath;
    public int FurthestPosition;

    public Vector2 Checkpoint;

    public bool ReturnToCheckpoint;

    public bool PlayerSucceed;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        ReturnToCheckpoint = false;
        SceneController.Instance.OnPhaseLoaded += InitiatePhase;
    }

    public void EndPhase(bool playerSucceed)
    {
        PlayerSucceed = playerSucceed;
        SceneController.Instance.LoadEndPhase();
        TimeTookOnPhase = Time.time - _timePhaseStart;
    }

    public void InitiatePhase()
    {
        Player = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<Player>();
        
        _timePhaseStart = Time.time;
        
        PointsOfDeath = new List<Vector2>();

        if (!ReturnToCheckpoint)
        {
            Checkpoint = Vector2.zero;
        }
        else
        {
            ReturnToCheckpoint = false;
        }

        FurthestPosition = 0;
        PositionPlayer();
    }

    public void RestartFromCheckpoint(Vector2 deathPosition)
    {
        PointsOfDeath.Add(deathPosition);
        int position = (int) deathPosition.x;
        FurthestPosition = position> FurthestPosition ? position : FurthestPosition;
        PositionPlayer();
    }
    
    public void PositionPlayer()
    {
        Player.DisableMovement();
        Player.transform.position = Checkpoint;
        StartCoroutine(nameof(StartMoving), 1.5f );
    }

    public void RecordCheckpoint(Vector2 position)
    {
        Checkpoint = position;
    }

    public float TimeTillMoment()
    {
        return Time.time - _timePhaseStart;
    }

    public IEnumerator StartMoving(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        Player.EnableMovement();
    }

}