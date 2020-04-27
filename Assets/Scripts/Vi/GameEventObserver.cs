using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventObserver : MonoBehaviour
{
    private static GameEventObserver _i;
    public static GameEventObserver i
    {
        get
        {
            if (_i == null)
            {
                _i = FindObjectOfType<GameEventObserver>();
            }
            return _i;
        }
    }

    [Header("Demon")]
    public AI_Demon demon;

    [Header("EventForDialogue")]
    [SerializeField]
    private List<DialogueSystem> dialogues = new List<DialogueSystem>();
    bool isTalking;

    [Header("SomeEvents")]
    public bool isBurningItems;

    public Door frontDoor;
    public GameObject endingTrigger;
    public GameObject policeSiren;
    public bool isEnding;
    public bool isRoomChange;
    public bool isEnterLilyRoom;

    private void Start()
    {
        demon = FindObjectOfType<AI_Demon>();
        GameEventManager.isEncounterDemon = false;
        isBurningItems = false;

    }

    public void CloseFrontDoor() {
        frontDoor.OpenDoor(false);
        frontDoor.canOpen = false;
        frontDoor.canClose = false;
    }

    public void UnlockFrontDoor() {
        frontDoor.OpenDoor(false);
        frontDoor.canOpen = true;
        frontDoor.canClose = true;
    }


    private void Update()
    {
     
        AcitveDialogue();
        if (isBurningItems) {
            frontDoor.canOpen = true;
            endingTrigger.SetActive(true);
            policeSiren.SetActive(true);
            isBurningItems = false;
        }
    }

    void AcitveDialogue() {
        if (!isTalking) {
            if (InventoryManager.i.IsReadFirst3Note() && GetDialogue(DialogueEventType.After3Notes) != null)
            {
                GetDialogue(DialogueEventType.After3Notes).SetActive(true);
                isTalking = true;
            }
            if (InventoryManager.i.IsReadLast4Notes() && GetDialogue(DialogueEventType.DestroyRitualItemCanKillDemon) != null) {
                GetDialogue(DialogueEventType.DestroyRitualItemCanKillDemon).SetActive(true);
                isTalking = true;
            }
            if (GameEventManager.isEncounterDemon && GetDialogue(DialogueEventType.FirstMeetDemon)!=null) {
                GetDialogue(DialogueEventType.FirstMeetDemon).SetActive(true);
                isTalking = true;
            }
            if (demon.IsFirstTimeGetridofPlayer() && GetDialogue(DialogueEventType.AfterBeingTraced)!=null) {
                GetDialogue(DialogueEventType.AfterBeingTraced).SetActive(true);
                isTalking = true;
            }

            if (isEnding && GetDialogue(DialogueEventType.Final) != null) {
                GetDialogue(DialogueEventType.Final).SetActive(true);
                isTalking = true;
            }
            if (isRoomChange && GetDialogue(DialogueEventType.RoomChange) != null)
            {
                GetDialogue(DialogueEventType.RoomChange).SetActive(true);
                isTalking = true;
            }
            if (isEnterLilyRoom && GetDialogue(DialogueEventType.LilysRoom) != null)
            {
                GetDialogue(DialogueEventType.LilysRoom).SetActive(true);
                isTalking = true;
            }
            if (IsDialougeCompleted() && GameEventManager.allRoom.Count >=5 && GetDialogue(DialogueEventType.AllRoomChange)!=null && GetDialogue(DialogueEventType.LilysRoom)==null) {
                GetDialogue(DialogueEventType.AllRoomChange).SetActive(true);
                isTalking = true;
            }
        }
      
    }

    public bool IsDialougeCompleted() {
        return InGameAssetManager.i.dialogueText.text == "";
    }

    GameObject GetDialogue(DialogueEventType dialogue)
    {
        foreach (DialogueSystem D in dialogues)
        {
            if (D.type == dialogue) {
                return D.gameObject;
            }
        }
        return null;
    }

    public void AddToEventDialogue(DialogueSystem system) {
        dialogues.Add(system);
    }

    public void RemoveEventDialogue(DialogueSystem system) {
        isTalking = false;
        dialogues.Remove(system);
    }
}
