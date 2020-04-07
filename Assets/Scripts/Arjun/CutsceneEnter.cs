using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject CutsceneCam;
    public AI_Base AI;

    void OnTriggerEnter (Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        SoundManager.PlaySound(SoundManager.InGameMusic.BeingTraced);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(15);
        thePlayer.SetActive(true);
        CutsceneCam.SetActive(true);
        AI.enabled = true;
        Destroy(transform.parent.gameObject);
    }

}
