using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour,IPointerEnterHandler,IPointerClickHandler,IPointerExitHandler
{
    public Color mouseoverColor;
    public string itemName;
    [TextArea(3,10)]
    public string itemDescription;
    public Sprite itemWholeImage;
    public bool isClick;


    public void OnPointerClick(PointerEventData eventData)
    {
        isClick = true;
        ShowDetail();
    }

    void ShowDetail()
    {
        InGameAssetManager.i.detailDescriptionPanel.SetActive(true);
        InGameAssetManager.i.itemName_Detail.text = itemName;
        InGameAssetManager.i.itemDescription_Deatil.text = itemDescription;
        InGameAssetManager.i.itemSprite_Detail.sprite = itemWholeImage;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        InGameAssetManager.i.itemName_InInventory.text = itemName;
        transform.parent.GetComponent<Image>().color = mouseoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DisableFunction();
    }
  
    private void OnDisable()
    {
        DisableFunction();
    }

    void DisableFunction()
    {
        InGameAssetManager.i.itemName_InInventory.text = null;
        transform.parent.GetComponent<Image>().color = Color.white;
    }
}







