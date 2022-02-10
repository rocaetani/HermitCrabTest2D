using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour
{
    public Image Life1;
    public Image Life2;
    public Image Life3;
    private int _lifeIndex;

    public Text Score;
    
    public void StartFilledLife()
    {
        Life1.enabled = true;
        Life2.enabled = true;
        Life3.enabled = true;
        _lifeIndex = 3;
    }

    public void EmptyLife()
    {
        switch (_lifeIndex)
        {
            case 3:
                Life3.enabled = false;
                _lifeIndex--;
                break;
            case 2:
                Life2.enabled = false;
                _lifeIndex--;
                break;
            case 1:
                Life1.enabled = false;
                _lifeIndex--;
                break;
        }
    }

    public void SetScore(int score)
    {
        Score.text = score + "m";
    }

}