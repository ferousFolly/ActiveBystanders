using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditScrollView : MonoBehaviour
{

    public Transform content;
    [Range(30, 500)]
    public float scrollSpeed;
    float currentContentY;

    private void Start()
    {
        currentContentY = content.localPosition.y;
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
}
