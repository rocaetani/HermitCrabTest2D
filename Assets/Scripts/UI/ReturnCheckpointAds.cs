using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCheckpointAds : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(nameof(PlayAd));
    }

    private IEnumerator PlayAd()
    {
        AdsManager.Instance.PlayAd();
        yield return new WaitForSeconds(1);
        while (AdsManager.Instance.IsShowingAd())
        {
            yield return new WaitForSeconds(0.1f);
        }

        Debug.Log("Retornou para Cena");
        GameManager.Instance.ReturnToCheckpoint = true;
        SceneController.Instance.LoadPhase(TagManager.GAME_SCENE_TAG);
        
    }
}
