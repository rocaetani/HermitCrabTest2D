using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    
    public delegate void OnPhaseLoadedDelegate(); 
    public event OnPhaseLoadedDelegate OnPhaseLoaded;

    //public static SceneController Instance;
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

    public void LoadPhase(String phaseName)
    {
        StartCoroutine(nameof(LoadPhaseAsync), phaseName);
    }

    public void LoadEndPhase()
    {
        SceneManager.LoadScene(TagManager.END_PHASE_SCENE_TAG);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(TagManager.MENU_SCENE_TAG);
    }
    
    IEnumerator LoadPhaseAsync(String phaseName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(phaseName);
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        OnPhaseLoaded?.Invoke();
    }

}