using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
    public UI_Button[] buttons;
    public LightControl[] lights;
    public GameObject blackPanel;

    bool isOptoin;

    public void ClickStart() {
        foreach (UI_Button button in buttons)
        {
            button.GetComponentInChildren<Animator>().SetBool("Dissolve", true);
        }

        foreach (LightControl light in lights)
        {
            light.isFlickering = true;
        }

        Invoke("StartDialogue", 2f);
        
    }

    public void ClickExit() {
        Application.Quit();
    }

    public void ClickOption(bool b) {
        isOptoin = b;
        buttons[1].GetComponentInChildren<Animator>().SetBool("Pressed", isOptoin);
    }

    public void ClickApply() {
        SoundManager.PlaySound(SoundManager.UI_SoundEffects.UI_Back);
    }

    void StartDialogue() {
        blackPanel.SetActive(true);
    }

    public void ChangeScene() {
        SceneManager.LoadScene(1);
    }
}
