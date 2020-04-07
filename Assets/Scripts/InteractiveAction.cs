using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InteractiveAction : MonoBehaviour
{
    private GameObject buttonE;
    private GameObject inventory;
    FirstPersonAIO AIO;
    PlayerDying playerState;

    public float slowMotionSpeed = 0f;
    public float Door_rayCastDistance = 4f;
    public float Item_rayCastDistance = 6f;

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
        OpenSettingPanel();
        SlowMotion();
        SetCursorActiveOrNot();
    }

    void ButtonE_Function() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Door_rayCastDistance))
        {
            switch (hit.collider.tag)
            {
                case "Open":
                    Door door = hit.transform.GetComponent<Door>();
                    buttonE.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E) && door.CanOpenDoor())
                    {
                        door.isOpening = true;
                        GameEventManager.IncreaseOpeningDoorNumbers();
                        SoundManager.PlaySound(SoundManager.SoundEffects.DoorOpen);
                        hit.collider.GetComponentInParent<Animator>().SetBool("Open", true);
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && door.CanCloseDoor())
                    {
                        door.isOpening = false;
                        GameEventManager.IncreaseOpeningDoorNumbers();
                        SoundManager.PlaySound(SoundManager.SoundEffects.DoorOpen);
                        hit.collider.GetComponentInParent<Animator>().SetBool("Open", false);
                    }

                    break;

            }
        }
        else
        {
            buttonE.SetActive(false);
        }
        if (Physics.Raycast(ray, out hit, Item_rayCastDistance))
        {
            switch (hit.collider.tag)
            {
                case "Note":
                    buttonE.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SoundManager.PlaySound(SoundManager.SoundEffects.ItemPickUp);
                        Destroy(hit.collider.gameObject);
                    }
                    break;
                case "Ritual":
                    buttonE.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SoundManager.PlaySound(SoundManager.SoundEffects.ItemPickUp);
                        ObjectCounter.theScore += 1;
                        ObjectCounter.isCollected = true;
                        Destroy(hit.collider.gameObject);
                    }
                    break;
            }
        }
        else {
            buttonE.SetActive(false);
        }
    }

    void ActiveFlashLight() {
        if (GameEventManager.canUseFlashLight) {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isFlashLightOpening)
                {
                    SoundManager.PlaySound(SoundManager.SoundEffects.FlashOn);
                    GameEventManager.IncreaseFlashLightUsedNumber();
                    isFlashLightOpening = true;
                }
                else
                {
                    SoundManager.PlaySound(SoundManager.SoundEffects.FlashOff);
                    isFlashLightOpening = false;
                }
            }
        }
        InGameAssetManager.i.flashLight.enabled = isFlashLightOpening;
    }

    void OpenSettingPanel() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOpeningSetting)
        {
            SoundManager.PlaySound(SoundManager.UI_SoundEffects.UI_ESC);
            isOpeningSetting = true;
        }
        InGameAssetManager.i.settingPanel.SetActive(isOpeningSetting);
    }

    void OpenInventory() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InGameAssetManager.i.detailDescriptionPanel.SetActive(false);
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

    void SetCursorActiveOrNot()
    {
        if (isOpeningInventory || isOpeningSetting || playerState.CurrentHealth <= 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    public void CloseESC()
    {
        isOpeningSetting = false;
    }
}
