using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public ItemType.type type;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            SoundManager.PlaySound(SoundManager.SoundEffects.ItemPickUp);
            ObjectCounter.theScore += 1;
            ObjectCounter.isCollected = true;
            InventoryManager.i.UpdateInventory(type);
            Destroy(gameObject);
        }
    }
}
