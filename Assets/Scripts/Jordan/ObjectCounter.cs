using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCounter : MonoBehaviour
{
    public GameObject ObjectiveText;
    public static int theScore;

    void Update()
    {
        ObjectiveText.GetComponent<Text>().text = "Collect Ritual Items: " + theScore + "/4";

    }
}
