﻿using System.Collections;
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
    public List<UIItem> itemInInventory = new List<UIItem>();


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
                itemInInventory.Add(o.GetComponent<UIItem>());
                break;
            }
        }
    }
    public bool IsReadFirst3Note()
    {
        List<UIItem> first3Notes = new List<UIItem>();
        int isClickNumber = 0;
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            switch (itemInInventory[i].itemName) {
                case "Note1":
                case "Note2":
                case "Note3":
                    if (!first3Notes.Contains(itemInInventory[i]))
                    {
                        first3Notes.Add(itemInInventory[i]);
                    }
                    break;
            }
        }
        if (first3Notes.Count == 3) {
            for (int i = 0; i < first3Notes.Count; i++)
            {
                if (first3Notes[i].isClick) {
                    isClickNumber += 1;
                }
            }
        }
        if (isClickNumber >= 3) {
            return true;
        }
        return false;
    }

    public bool IsReadLast4Notes()
    {
        List<UIItem> last4Notes = new List<UIItem>();
        int isClickNumber = 0;
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            switch (itemInInventory[i].itemName)
            {
                case "Note4":
                case "Note5":
                case "Note6":
                case "Note7":
                    if (!last4Notes.Contains(itemInInventory[i]))
                    {
                        last4Notes.Add(itemInInventory[i]);
                    }
                    break;
            }
        }
        if (last4Notes.Count == 4)
        {
            for (int i = 0; i < last4Notes.Count; i++)
            {
                if (last4Notes[i].isClick)
                {
                    isClickNumber += 1;
                }
            }
        }
        if (isClickNumber >= 4)
        {
            return true;
        }
        return false;

    }
}
