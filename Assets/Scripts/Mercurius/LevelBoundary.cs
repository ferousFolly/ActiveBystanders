using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public GameObject blockText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            blockText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            blockText.SetActive(false);
        }
    }

}
