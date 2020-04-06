using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIItem : MonoBehaviour/*, IPointerEnterHandler*/
{

    public string mystring;
    public Text myText;
    public GameObject Flask;
    public float fadeText;
    public bool FlaskDes;
    public GameObject Cross;
    public GameObject Candle;
    public void Start()
    {
        myText = GameObject.Find("Text").GetComponent<Text>();
        myText.color = Color.clear;
        //Flask = GameObject.Find("Flask").GetComponent<GameObject>();
    }

    public void Update()
    {
        FadeText();
    }
    public void OnMouseOver()
    {
        FlaskDes = true;
        Debug.Log("llllll");  //it works but not appering 
    }

    public void OnMouseExit()
    {
        FlaskDes = false;
    }

    public void FadeText()
    {
        if (FlaskDes)
        {
            myText.text = mystring;
            myText.color = Color.Lerp(myText.color, Color.white, fadeText * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeText * Time.deltaTime);
        }

    }
}


//    public void OpenSprite()
//    {
//        if (Flask != null)
//        {
//            bool isAvtive = Flask.activeSelf;

//            Flask.SetActive(!isAvtive);
//        }


//    }
//    public void OnPointerEnter(PointerEventData eventData)
//    {

//        if (Flask == true)
//        {
//            Flask.SetActive(Flask);
//        }
//        Debug.Log("AA");
//    }
//}






