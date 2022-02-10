using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceManager : MonoBehaviour
{

    public static bool IOS;

    public static bool Android;

    public static bool UnityEditor;

    public static bool PC;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        IOS = false;
        Android = false;
        UnityEditor = false;
        PC = false;

        ValidateDevices();
    }


    private void ValidateDevices()
    {
#if UNITY_EDITOR
        UnityEditor = true;
#endif
            
#if UNITY_ANDROID
        Android = true;
#endif
            
#if UNITY_IOS
        IOS = true;
#endif
            
#if UNITY_EDITOR_WIN
        PC = true;
#endif
    }


}
