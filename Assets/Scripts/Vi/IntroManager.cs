using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{

    public GameObject panel;
    void Start()
    {
        panel.SetActive(true);
    }

    public void NextScene() {
        SceneControlle.NextScene();
    }
}
