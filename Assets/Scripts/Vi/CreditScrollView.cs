using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScrollView : MonoBehaviour
{

    public Transform content;
    [Range(30, 500)]
    public float scrollSpeed;
    float currentContentY;
    public Text creditTExt;
    [TextArea(3,30)]
    public string credit;
    public string[] titles;

    private void Start()
    {
        currentContentY = content.localPosition.y;
        for (int i = 0; i < titles.Length; i++)
        {
            credit = credit.Replace(titles[i], BoldAndRedText(titles[i]));
        }
        creditTExt.text = credit;
    }

    void Update()
    {
        float y = content.localPosition.y;
        if (y <= Mathf.Abs(currentContentY))
        {
            content.localPosition = new Vector3(0, y += Time.deltaTime * scrollSpeed, 0);
        }
        else
        {
            SceneControlle.JumpScene(0);
        }
    }

    string BoldAndRedText(string s) {
        return $"<color=red><b><size=70>{s}</size></b></color>";
    }
}
