using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject CutsceneCam;

    void OnTriggerEnter (Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        CutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        StartCoroutine(FinishCut());
    }

    IEnumerator FinishCut()
    {
        yield return new WaitForSeconds(16);
        thePlayer.SetActive(true);
        CutsceneCam.SetActive(true);
    }
}
