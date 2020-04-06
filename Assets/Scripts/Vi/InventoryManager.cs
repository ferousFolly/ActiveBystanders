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
        Candelabra,
        Cross,
        Blood_flask,
        Gun,
        FlashLight,
    }
    public string itemName;
    public type typeOfItem;
    public Sprite itemSpriteIcon;
    [TextArea(3,10)]
    public string Description;
    public Sprite itemWholeSprite;
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

    private void Start()
    {
        UpdateInventory(ItemType.type.Gun);
        UpdateInventory(ItemType.type.FlashLight);
    }

    public void UpdateInventory(ItemType.type _type) {
        GameObject o = Instantiate(InGameAssetManager.i.itemPrefab);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].typeOfItem == _type)
            {
                o.GetComponent<Image>().sprite = items[i].itemSpriteIcon;
                o.GetComponent<UIItem>().itemName = items[i].itemName;
                o.GetComponent<UIItem>().itemDescription = items[i].Description;
                o.GetComponent<UIItem>().itemWholeImage = items[i].itemWholeSprite;
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
