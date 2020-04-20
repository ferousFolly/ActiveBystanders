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
        OptionalNote_1,
        OptionalNote_2,
        OptionalNote_3,
        None,
    }
    public string itemName;
    public type typeOfItem;
    public Sprite itemSpriteIcon;
    [TextArea(3,10)]
    public string Description;
    [TextArea(3, 10)]
    public string textCanBeHighlighted;
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
        AddInnventory(ItemType.type.Gun);
        AddInnventory(ItemType.type.FlashLight);
    }

    public void AddInnventory(ItemType.type _type) {
        GameObject o = Instantiate(InGameAssetManager.i.itemPrefab);

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].typeOfItem == _type)
            {
                if (items[i].textCanBeHighlighted != "")
                {
                    items[i].Description = items[i].Description.Replace(items[i].textCanBeHighlighted, NewLighHighText(items[i].textCanBeHighlighted));
                }
              
                o.GetComponent<Image>().sprite = items[i].itemSpriteIcon;
                o.GetComponent<UIItem>().itemName = items[i].itemName;
                o.GetComponent<UIItem>().type = items[i].typeOfItem;
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

    public void RemoveFromInventory(ItemType.type _item) {
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            if (itemInInventory[i].type == _item) {
                Destroy(itemInInventory[i].gameObject);
                itemInInventory.Remove(itemInInventory[i]);
            }
        }
    }

    string NewLighHighText(string s)
    {
        return $"<color=red>{s}</color>";
    }


    public bool IsReadFirst3Note()
    {
        List<UIItem> first3Notes = new List<UIItem>();
        int isClickNumber = 0;
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            switch (itemInInventory[i].type.ToString()) {
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
            switch (itemInInventory[i].type.ToString())
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

    public void BurnRitualItems() {
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            switch (itemInInventory[i].itemName)
            {
                case "Candelabra":
                case "Cross":
                case "Blood Flask":
                    if (itemInInventory.Contains(itemInInventory[i]))
                    {
                        Destroy(itemInInventory[i].gameObject);
                        itemInInventory.Remove(itemInInventory[i]);
                    }
                    break;
            }
        }
    }
}
