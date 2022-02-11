using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Text TimeTaken;
    private bool _alreadyMarked;

    private void Start()
    {
        TimeTaken.enabled = false;
        _alreadyMarked = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG) && !_alreadyMarked)
        {
            GameManager.Instance.RecordCheckpoint(transform.position);
            SetTime(TimeFormatter.Format((int) GameManager.Instance.TimeTillMoment()));
            _alreadyMarked = true;
        }
    }


    private void SetTime(String time)
    {
        TimeTaken.text = time;
        TimeTaken.enabled = true;
    }
}
