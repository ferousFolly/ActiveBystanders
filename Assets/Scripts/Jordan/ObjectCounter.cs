﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    public Image objecttiveBG;
    public Text ObjectiveText;
    public Color BGColor;
    public Color textColor;
    public float showingTimer = 2.5f;
    private float currentShowingTimer;
    public static int theScore;
    public static bool isCollected;


    private void Start()
    {
        objecttiveBG.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateText();
    }

    void UpdateText() {
        if (isCollected) {
            objecttiveBG.gameObject.SetActive(true);
            ObjectiveText.GetComponent<Text>().text = "Collect Ritual Items: " + theScore + "/4";
            objecttiveBG.color = BGColor;
            ObjectiveText.color = textColor;
            if (currentShowingTimer < showingTimer)
            {
                currentShowingTimer += Time.deltaTime;
            }
            else {
                BGColor.a -= Time.deltaTime;
                textColor.a -= Time.deltaTime;

                if (BGColor.a <= 0)
                {
                    currentShowingTimer = 0;
                    BGColor.a = 1;
                    textColor.a = 1;
                    objecttiveBG.gameObject.SetActive(false);
                    isCollected = false;
                }
            }
        }
    }
}
