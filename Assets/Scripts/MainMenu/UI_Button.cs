using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInChildren<Animator>().SetBool("HighLight",true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<Animator>().SetBool("HighLight", false);
    }
}
