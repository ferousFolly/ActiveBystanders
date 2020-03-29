using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractiveAction : MonoBehaviour
{
    private GameObject buttonE;
    private GameObject inventory;
    FirstPersonAIO AIO;

    public float slowMotionSpeed = 0.05f;

    bool isFlashLightOpening;
    bool isOpeningInventory;

    private void Start()
    {
        buttonE = InGameAssetManager.i.buttonE;
        inventory = InGameAssetManager.i.inventory;
        isFlashLightOpening = InGameAssetManager.i.flashLight.enabled;
        AIO = GetComponent<FirstPersonAIO>();
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
                        SoundManager.PlaySound(SoundManager.SoundEffects.DoorOpen);
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
        if (GameEventManager.canUseFlashLight) {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isFlashLightOpening)
                {
                    GameEventManager.IncreaseFlashLightUsedNumber();
                    isFlashLightOpening = true;
                }
                else
                {
                    isFlashLightOpening = false;
                }
            }
        }
        InGameAssetManager.i.flashLight.enabled = isFlashLightOpening;
    }

    void OpenInventory() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isOpeningInventory = !isOpeningInventory;
            AIO.lockAndHideCursor = !isOpeningInventory;
        }
        SlowMotion();
        inventory.SetActive(isOpeningInventory);
    }

    void SlowMotion() {
        if (isOpeningInventory)
        {
            Time.timeScale = slowMotionSpeed;
        }
        else {
            Time.timeScale = 1f;
        }
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
