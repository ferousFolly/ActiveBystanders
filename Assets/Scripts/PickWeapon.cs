using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickWeapon : MonoBehaviour
{

    public GameObject buttonE;
    bool isShowingButton;
    bool isHoldingWeapon;
    [SerializeField]
    GameObject weapon;

    void Update()
    {
        if (isShowingButton)
        {
            if (Input.GetKeyDown(KeyCode.E) && weapon != null)
            {
                weapon.transform.SetParent(transform.GetChild(0).GetChild(0));
                weapon.transform.localPosition = Vector3.zero;
                isHoldingWeapon = true;
                isShowingButton = false;
            }
            if (!isHoldingWeapon)
            {
                buttonE.SetActive(true);
            }
            else
            {
                buttonE.SetActive(false);
            }
        }
        else {
            buttonE.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Open")
        {
            if (Input.GetKeyDown(KeyCode.E)) { 
            other.GetComponent<Animator>().SetBool("Open", true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon") {
            isShowingButton = true;
            weapon = other.transform.parent.gameObject;
        }
    }




    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weapon")
        {
            isShowingButton = false;
            weapon = null;
        }
    }
}
