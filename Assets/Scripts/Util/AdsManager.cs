using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
#if UNITY_IOS
    string gameId= "4597371";
#else
    string gameId= "4603680";
#endif

    public String AdName;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId);
    }

    public void PlayAd()
    {
        if (Advertisement.IsReady(AdName))
        {
            Advertisement.Show(AdName);
        }
    }
}
