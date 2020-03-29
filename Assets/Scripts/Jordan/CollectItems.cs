using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            SoundManager.PlaySound(SoundManager.SoundEffects.ItemPickUp);
            ObjectCounter.theScore += 1;
            ObjectCounter.isCollected = true;
            Destroy(gameObject);
        }
    }
}
