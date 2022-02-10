using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EndPhasePlatform : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            GameManager.Instance.EndPhase(true);
        }
    }
}