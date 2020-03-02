using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour
{
    public UI_Button[] buttons;
    public LightControl[] lights;

    public void ClickStart() {
        foreach (UI_Button button in buttons)
        {
            button.DissolveButton();
        }

        foreach (LightControl light in lights)
        {
            light.isFlickering = true;
        }

        Invoke("ChangeScene",2f);
        
    }

    public void ClickExit() {
        Application.Quit();
    }

    void ChangeScene() {
        SceneManager.LoadScene(1);
    }
}
