using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    public Image objecttiveBG;
    public Image FadeBlack;
    public Text ObjectiveText;
    public Color BGColor;
    public Color textColor;
    public float showingTimer = 2.5f;
    private float currentShowingTimer;
    public static int theScore;
    public static bool isCollected;

  

    float colorFadeBlack = 0f;


    private void Start()
    {
        theScore = 0;
        objecttiveBG.gameObject.SetActive(false);
        colorFadeBlack = FadeBlack.color.a;
    }

    void Update()
    {
        UpdateText();

        //if (theScore >= 3)
        //{
        //    colorFadeBlack += Time.deltaTime;
        //}
        //if (colorFadeBlack>=1) {
        //    SceneControlle.NextScene();
        //}
        //FadeBlack.color = new Color(1, 1, 1, colorFadeBlack);
    }


    void UpdateText() {
        if (isCollected) {
            objecttiveBG.gameObject.SetActive(true);
            ObjectiveText.GetComponent<Text>().text = "Collect Ritual Items: " + theScore + "/3";

            objecttiveBG.color = BGColor;
            ObjectiveText.color = textColor;

            if (currentShowingTimer < showingTimer)
            {
                currentShowingTimer += Time.unscaledDeltaTime;
            }
            else {
                BGColor.a -= Time.unscaledDeltaTime;
                textColor.a -= Time.unscaledDeltaTime;

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
