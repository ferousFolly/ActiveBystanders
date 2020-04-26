using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEnter : MonoBehaviour
{
    private GameObject thePlayer;
    public GameObject CutsceneCam;
    public AI_Base AI;

    private void Start()
    {
        thePlayer = InGameAssetManager.i.player;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            CutsceneCam.SetActive(true);
            thePlayer.SetActive(false);
            SoundManager.PlaySound(SoundManager.InGameMusic.BeingTraced);
            StartCoroutine(FinishCut());
        }
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
