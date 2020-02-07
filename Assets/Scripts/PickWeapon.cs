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
                weapon.transform.SetParent(transform.GetChild(0));
                weapon.transform.eulerAngles = new Vector3(-15, 110, -55);
                isHoldingWeapon = true;
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
