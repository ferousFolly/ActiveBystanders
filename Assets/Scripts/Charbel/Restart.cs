using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
     public void PlayGame()
    {
        SceneManager.LoadScene("ActualMain");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 

        {
              SceneManager.LoadScene("ActualMain");
        }
    }





}



