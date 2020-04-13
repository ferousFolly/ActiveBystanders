using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public GameObject blockText;

    private void OnTriggerEnter(Collider other)
    {
        blockText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        blockText.SetActive(false);
    }

}
