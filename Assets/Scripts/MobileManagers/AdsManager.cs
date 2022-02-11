using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public String AdName;

    public static AdsManager Instance;

    private String _sulfix;

    private String gameId;
    
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
    
    // Start is called before the first frame update
    void Start()
    {
        if (DeviceManager.IOS)
        {
            _sulfix = "_iOS";
            gameId= "4608262";

        }
        if (DeviceManager.Android)
        {
            _sulfix = "_Android";
            gameId= "4608263";
        }

        Advertisement.Initialize(gameId);
        AdName += _sulfix;
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady(AdName))
        {
            Advertisement.Show(AdName);
        }
    }

    public bool IsShowingAd()
    {
        return Advertisement.isShowing;
    }
}
