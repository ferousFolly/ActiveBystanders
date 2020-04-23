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

    bool canBurnArea;
    bool canInteractive;
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
                    canInteractive = true;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (door.canOpen)
                        {
                            if (door.CanOpenDoor())
                            {
                                GameEventManager.IncreaseOpeningDoorNumbers();
                                door.OpenDoor(true);
                            }
                            else if (door.CanCloseDoor())
                            {
                                door.OpenDoor(false);
                            }
                        }
                        else {
                            SoundManager.PlaySound(SoundManager.SoundEffects.DoorLock);
                        }
                    }
                    break;
            }
        }
        else
        {
            if (canBurnArea)
            {
                canInteractive = true;
            }
            else {
                canInteractive = false;
            }
        }
        if (Physics.Raycast(ray, out hit, Item_rayCastDistance))
        {
            switch (hit.collider.tag)
            {
                case "Note":
                    canInteractive = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SoundManager.PlaySound(SoundManager.SoundEffects.PaperPickUp);
                        hit.transform.GetComponent<CollectItems>().DisableText();
                        Destroy(hit.collider.gameObject);
                    }
                    break;
                case "Ritual":
                    canInteractive = true;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SoundManager.PlaySound(SoundManager.SoundEffects.ItemPickUp);
                        ObjectCounter.theScore += 1;
                        ObjectCounter.isCollected = true;
                        hit.transform.GetComponent<CollectItems>().DisableText();
                        Destroy(hit.collider.gameObject);
                    }
                    break;
            }
        }
        else {
            if (canBurnArea)
            {
                canInteractive = true;
            }
            else
            {
                canInteractive = false;
            }
        }
        buttonE.SetActive(canInteractive);
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
            InGameAssetManager.i.settingPanel.SetActive(true);
        }
        isOpeningSetting = InGameAssetManager.i.settingPanel.activeInHierarchy;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fire" && ObjectCounter.theScore >= 3 && !GameEventObserver.i.isBurningItems)
        {
            canBurnArea = true;
        }
        if (other.tag == "CloseDoorTrigger") {
            GameEventObserver.i.CloseFrontDoor();
            Destroy(other.gameObject);
        }
        if (other.tag == "Ending") {
            GameEventObserver.i.CloseFrontDoor();
            GameEventObserver.i.isEnding = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Fire" && ObjectCounter.theScore >= 3 && !GameEventObserver.i.isBurningItems)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //InventoryManager.i.BurnRitualItems();
                InventoryManager.i.RemoveFromInventory(ItemType.type.Cross);
                InventoryManager.i.RemoveFromInventory(ItemType.type.Candelabra);
                InventoryManager.i.RemoveFromInventory(ItemType.type.Blood_flask);
                GameEventObserver.i.isBurningItems = true;
                canBurnArea = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Fire" && ObjectCounter.theScore >= 3 && !GameEventObserver.i.isBurningItems)
        {
            canBurnArea = false;

        }
    }
}
