using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneController.Instance.LoadPhase(TagManager.FIRST_PHASE_SCENE_TAG);
    }
}