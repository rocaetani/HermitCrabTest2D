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

    private float _timeBeforeReturnToCheckpoint;
    
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
        UpdateFurthestPosition((int) Player.transform.position.x);
        TimeTookOnPhase = (Time.time - _timePhaseStart) + _timeBeforeReturnToCheckpoint;
        SceneController.Instance.LoadEndPhase();
    }

    public void InitiatePhase()
    {
        Player = GameObject.FindWithTag(TagManager.PLAYER_TAG).GetComponent<Player>();
        
        _timePhaseStart = Time.time;
        
        PointsOfDeath = new List<Vector2>();
        
        Player.SetToIdle();

        if (!ReturnToCheckpoint)
        {
            Checkpoint = Vector2.zero;
            _timeBeforeReturnToCheckpoint = 0;
        }
        else
        {
            _timeBeforeReturnToCheckpoint = TimeTookOnPhase;
            ReturnToCheckpoint = false;
            
        }

        FurthestPosition = 0;
        PositionPlayer();
    }

    public void RestartFromCheckpoint(Vector2 deathPosition)
    {
        PointsOfDeath.Add(deathPosition);
        int position = (int) deathPosition.x;
        UpdateFurthestPosition(position);
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
        return Time.time - _timePhaseStart + _timeBeforeReturnToCheckpoint;
    }

    public IEnumerator StartMoving(float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        Player.EnableMovement();
    }

    public void UpdateFurthestPosition(int position)
    {
        FurthestPosition = position > FurthestPosition ? position : FurthestPosition;
    }

}