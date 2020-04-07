using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newinventory : MonoBehaviour
{
    //private static InventoryManager _i;
    //public static InventoryManager i
    //{
    //    get
    //    {
    //        if (_i == null)
    //        {
    //            _i = FindObjectOfType<InventoryManager>();
    //        }
    //        return _i;
    //    }
    //}

    //public List<ItemType> items = new List<ItemType>();
    //public Transform slots;

    //public float distance;

    //GameObject inventoryObj;

    //GameObject[] go;
    ////[0 SLOT][1 INVENTORY][2 HOTBAR][3 ITEM]

    //Transform[] t;
    //// [0 CONTAINER][1 INVENTORY][2 HOTBAR][3 SLOTS][4 OPTIONS][5 DOC VIEW]

    //Sprite error;

    //bool o;
    //Transform playerCamera, canvas, invSlots;
    //FirstPersonAIO pm;
    //CanvasScaler cs;
    //Dropdown sort;
    //Text info;


    //private void Start()
    //{


    //    foreach (Transform child in transform)
    //        if (child.GetComponent<Camera>() != null)
    //            playerCamera = child;

    //    foreach (Transform child in transform)
    //        if (child.GetComponent<FirstPersonAIO>() != null)


    //            if (GetComponent<FirstPersonAIO>() != null)

    //                canvas = GameObject.Find("Canvas").transform;
    //    cs = canvas.GetComponent<CanvasScaler>();
    //    cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
    //    cs.referenceResolution = new Vector2(1280, 720);
    //    cs.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
    //    cs.matchWidthOrHeight = 0.5f;

    //    go = new GameObject[5];
    //    t = new Transform[7];
    //    go[0] = Resources.Load<GameObject>("Core/QIS/_slot");
    //    go[1] = Resources.Load<GameObject>("Core/QIS/_inventory");
    //    go[2] = Resources.Load<GameObject>("Core/QIS/_hotbar");
    //    go[3] = Resources.Load<GameObject>("Core/QIS/_erit");
    //    error = Resources.Load<Sprite>("Core/QIS/_ertex");
    //    t[1] = Instantiate<GameObject>(go[1], canvas).transform;
    //    invSlots = t[1].Find("_slots");
    //    t[0] = t[1].Find("_container");
    //    t[4] = t[1].Find("_options");
    //    t[3] = t[4].Find("_moreSlots");
    //    t[5] = t[1].Find("_docViewer");
    //    t[2] = Instantiate<GameObject>(go[2], canvas).transform;
    //    t[6] = t[4].Find("_info");
    //    sort = t[4].Find("_sort").GetComponent<Dropdown>();

    //    info = t[6].Find("Text").GetComponent<Text>();
    //    t[1].gameObject.SetActive(false);
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown("E"))
    //    {
    //        RaycastHit hit;
    //        int layer = gameObject.layer;
    //        gameObject.layer = 2;
    //        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, distance))
    //        {
    //            GameObject o = Instantiate(InGameAssetManager.i.itemPrefab);
    //            for (int i = 0; i < items.Count; i++)
    //            {

    //                o.GetComponent<Image>().sprite = items[i].itemSprite;

    //            }
    //            for (int i = 0; i < slots.childCount; i++)
    //            {
    //                if (slots.GetChild(i).childCount == 0)
    //                {
    //                    Transform emptySlot = slots.GetChild(i);
    //                    o.transform.SetParent(emptySlot, false);
    //                    break;
    //                }

    //            }
    //        }
    //    }
    //}
}
