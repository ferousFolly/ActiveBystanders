using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public ItemType.type type;
    [TextArea(3,10)]
    public string shortDescription;
    public float text3DPopup_Height;
    private GameObject text3D;

    private void Start()
    {
        text3D = InGameAssetManager.i.text3D;
    }


    private void OnMouseEnter()
    {
        text3D.SetActive(true);
        text3D.transform.position = new Vector3(transform.position.x,transform.position.y+ text3DPopup_Height,transform.position.z);
        text3D.GetComponentInChildren<TextMesh>().text = shortDescription;
        text3D.transform.LookAt(new Vector3(InGameAssetManager.i.player.transform.position.x,transform.position.y,InGameAssetManager.i.player.transform.position.z));
    }

    private void OnMouseExit()
    {
        text3D.SetActive(false);
        text3D.GetComponentInChildren<TextMesh>().text = null;
    }

    private void OnDestroy()
    {
        text3D.SetActive(false);
        text3D.GetComponentInChildren<TextMesh>().text = null;
        InventoryManager.i.UpdateInventory(type);
    }
}
