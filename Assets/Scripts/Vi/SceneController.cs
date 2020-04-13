using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlle
{
    public static void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ReLoad() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void JumpScene(int i) {
        SceneManager.LoadScene(i);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }

}
