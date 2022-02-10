using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTouch : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            GameManager.Instance.Player.ReduceLife();
        }
    }
}