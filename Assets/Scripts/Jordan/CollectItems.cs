using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public AudioSource collectSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            collectSound.Play();
            ObjectCounter.theScore += 1;
            ObjectCounter.isCollected = true;
            Destroy(gameObject);
        }
    }
}
