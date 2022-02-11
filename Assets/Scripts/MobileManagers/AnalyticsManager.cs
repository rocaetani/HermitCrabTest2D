using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance;
    
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
    
    public void AddDeathPosition(Vector2 position)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent("DeathPosition", position);
        Debug.Log("analyticsResult: "+ analyticsResult);
    }
}
