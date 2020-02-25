using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickWeapon : MonoBehaviour {

    bool isShowingButton;
    bool isHoldingWeapon;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject buttonE;
    [SerializeField] GameObject weapon;

    void Update() {
        if (isShowingButton) {
            if (Input.GetKeyDown(KeyCode.E) && weapon != null) {
                weapon.transform.SetParent(transform.GetChild(0).GetChild(0));
                weapon.transform.localPosition = Vector3.zero;
                isHoldingWeapon = true;
                isShowingButton = false;
            }
            if (!isHoldingWeapon) {
                buttonE.SetActive(true);
            }
            else {
                buttonE.SetActive(false);
            }
        }
        else {
            buttonE.SetActive(false);
        }
        if (isHoldingWeapon) {
            weapon.transform.rotation = mainCamera.transform.rotation;
            weapon.transform.rotation.SetLookRotation(mainCamera.transform.rotation.eulerAngles); //Quaternion.AngleAxis(-90, Vector3.up);
            weapon.transform.localEulerAngles -= Vector3.up * 90;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Weapon") {
            isShowingButton = true;
            weapon = other.transform.parent.gameObject;
        }

        if (other.tag == "Open") {
            other.GetComponentInParent<Animator>().SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Weapon") {
            isShowingButton = false;
            weapon = null;
        }
    }
}
