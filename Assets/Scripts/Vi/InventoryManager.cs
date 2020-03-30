using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemType {
    public enum type
    {
        Note1,
        Note2,
        Note3,
        Note4,
        Note5,
        Note6,
        Note7,
        Flare,
        RituralItem1,
        RituralItem2,
        RituralItem3,
        RituralItem4,
    }

    public type typeOfItem;
    public Sprite itemSprite;
}

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _i;
    public static InventoryManager i {
        get {
            if (_i == null) {
                _i = FindObjectOfType<InventoryManager>();
            }
            return _i;
        }
    }

    public List<ItemType> items = new List<ItemType>();
    public Transform slots;

    public void UpdateInventory(ItemType.type _type) {
        GameObject o = Instantiate(InGameAssetManager.i.itemPrefab);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].typeOfItem == _type)
            {
                o.GetComponent<Image>().sprite = items[i].itemSprite;
            }
        }
        for (int i = 0; i < slots.childCount; i++)
        {
            if (slots.GetChild(i).childCount == 0)
            {
                Transform emptySlot = slots.GetChild(i);
                o.transform.SetParent(emptySlot, false);
                break;
            }
        }
    
    }
}
