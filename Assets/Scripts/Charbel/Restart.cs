using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Restart : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneControlle.ReLoad();
        }
    }
}



