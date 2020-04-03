using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence ()
    {
        Cam1.SetActive(true);
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
        yield return new WaitForSeconds(4);
        Cam4.SetActive(true);
        Cam3.SetActive(false);
    }
}
