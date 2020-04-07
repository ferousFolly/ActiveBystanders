using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public UnityEvent onButtonClick;

    void Start() {
        GetComponentInChildren<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInChildren<Animator>().SetBool("HighLight",true);
        SoundManager.PlaySound(SoundManager.UI_SoundEffects.UI_HighLight);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInChildren<Animator>().SetBool("HighLight", false);
    }

    void OnClick() {
        if (onButtonClick != null) {
            onButtonClick.Invoke();
        }
    }
}
