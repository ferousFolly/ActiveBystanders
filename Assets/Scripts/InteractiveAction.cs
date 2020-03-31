﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractiveAction : MonoBehaviour
{
    private GameObject buttonE;
    private GameObject inventory;
    FirstPersonAIO AIO;
    PlayerDying playerState;

    public float slowMotionSpeed = 0.05f;

    bool isFlashLightOpening;
    bool isOpeningInventory;
    bool isOpeningSetting;

    Color inventoryBGColor;

    private void Start()
    {
        buttonE = InGameAssetManager.i.buttonE;
        inventory = InGameAssetManager.i.inventory;
        isFlashLightOpening = InGameAssetManager.i.flashLight.enabled;
        AIO = GetComponent<FirstPersonAIO>();
        inventoryBGColor = new Color(0,0,0,0);
        InGameAssetManager.i.inventoryBG.color = inventoryBGColor;
        playerState = GetComponent<PlayerDying>();
    }

    void Update()
    {
        ButtonE_Function();
        ActiveFlashLight();
        OpenInventory();
        SlowMotion();
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SoundManager.PlaySound(SoundManager.UI_SoundEffects.UI_ESC);
            isOpeningSetting = true;
        }
        InGameAssetManager.i.settingPanel.SetActive(isOpeningSetting);
        SetCursorActiveOrNot();
    }

    void ButtonE_Function() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f))
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
            SoundManager.PlaySound(SoundManager.UI_SoundEffects.UI_OpenInventory);
            isOpeningInventory = !isOpeningInventory;
        }
        inventory.SetActive(isOpeningInventory);
    }

    void SlowMotion() {
        if (isOpeningInventory || isOpeningSetting || playerState.CurrentHealth <= 0f)
        {
            InGameAssetManager.i.gunScript.enabled = false;
            Time.timeScale = slowMotionSpeed;
            if (inventoryBGColor.a < 0.6f)
            {
                inventoryBGColor.a += Time.unscaledDeltaTime;
            }
        }
        else {
            InGameAssetManager.i.gunScript.enabled = true;
            inventoryBGColor.a = 0;
            Time.timeScale = 1f;
        }
        InGameAssetManager.i.inventoryBG.color = inventoryBGColor;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void CloseESC() {
        isOpeningSetting = false;
    }

    void SetCursorActiveOrNot()
    {
        if (isOpeningInventory || isOpeningSetting)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
