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
    public bool enableRandomPosition;
    public Transform[] demonAppearPoints;
    private GameObject demon;
    public GameObject demonPrefab;
    public float appearTime;
    public float disAppearTime;
    bool isVanishing;

    [Header("EventForDialogue")]
    [SerializeField]
    private List<DialogueSystem> dialogues = new List<DialogueSystem>();
    bool isTalking;

    [Header("SomeEvents")]
    public bool isBurningItems;

    public bool isClosingFrontDoor;
    public Door frontDoor;
    public GameObject endingTrigger;
    public GameObject policeSiren;
    public bool isEnding;

    private void Start()
    {
        if (enableRandomPosition) {
            demon = FindObjectOfType<AI_Demon>().gameObject;
        }
        GameEventManager.isEncounterDemon = false;
        isBurningItems = false;
    }

    private void Update()
    {
        if (enableRandomPosition) {
            RandomSpawn();
        }
        AcitveDialogue();
        if (isClosingFrontDoor) {
            frontDoor.OpenDoor(false);
            frontDoor.canOpen = false;
            frontDoor.canClose = false;
            isClosingFrontDoor = false;
        }
        if (isBurningItems) {
            frontDoor.canOpen = true;
            endingTrigger.SetActive(true);
            policeSiren.SetActive(true);
        }
    }

    void RandomSpawn() {
        if (!isVanishing) {
            StartCoroutine(Appear());
        }
    }

    IEnumerator Appear() {
        isVanishing = true;
        yield return new WaitForSeconds(disAppearTime);
        Transform nextSpawnPoint = demonAppearPoints[Random.Range(0, demonAppearPoints.Length)];
        Destroy(demon);
        yield return new WaitForSeconds(appearTime);
        GameObject D = Instantiate(demonPrefab);
        D.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        D.transform.position = nextSpawnPoint.position;
        yield return new WaitForSeconds(0.1f);
        D.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        demon = D;
        isVanishing = false;
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
        }
      
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
