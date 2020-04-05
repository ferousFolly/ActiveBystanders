using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLog : MonoBehaviour
{
    public GameObject Log;
    void Start()
    {
        if(Input.GetKeyDown("j"))
        {
            Log.SetActive(true);
        }
        else
        {
            Log.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
