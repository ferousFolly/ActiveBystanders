using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractiveAction : MonoBehaviour
{

    public GameObject buttonE;


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.2f))
        {
            switch (hit.collider.tag)
            {
                case "Open":
                    buttonE.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        hit.collider.GetComponentInParent<Animator>().SetBool("Open", true);
                    }
                    break;
            }
        }
        else {
            buttonE.SetActive(false);
        }
    }
}
