using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneController.Instance.LoadPhase(TagManager.GAME_SCENE_TAG);
    }
}