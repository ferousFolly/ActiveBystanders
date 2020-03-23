using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractiveAction : MonoBehaviour
{
    private GameObject buttonE;
    private GameObject inventory;

    bool isFlashLightOpening;
    bool isOpeningInventory;

    private void Start()
    {
        buttonE = InGameAssetManager.i.buttonE;
        inventory = InGameAssetManager.i.inventory;
        isFlashLightOpening = InGameAssetManager.i.flashLight.enabled;
    }

    void Update()
    {
        ButtonE_Function();
        ActiveFlashLight();
        OpenInventory();
    }

    void ButtonE_Function() {
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
                        GameEventManager.IncreaseOpeningDoorNumbers();
                        hit.collider.GetComponentInParent<Animator>().SetBool("Open", true);
                    }
                    break;
            }
        }
        else
        {
            buttonE.SetActive(false);
        }
    }

    void ActiveFlashLight() {
        if (Input.GetKeyDown(KeyCode.F)) {
            if (!isFlashLightOpening)
            {
                GameEventManager.IncreaseFlashLightUsedNumber();
                isFlashLightOpening = true;
            }
            else {
                isFlashLightOpening = false;
            }
        }
        InGameAssetManager.i.flashLight.enabled = isFlashLightOpening;
    }

    void OpenInventory() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOpeningInventory = !isOpeningInventory;
        }
        inventory.SetActive(isOpeningInventory);
    }

}
