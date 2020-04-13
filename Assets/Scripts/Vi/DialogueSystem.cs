using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class DialogueText {
    [TextArea(3, 30)]
    public string dialogueText;
    public float duration = 3f;
    public AudioClip voiceLine;
    [HideInInspector]
    public bool isPlaying;
}

public enum DialogueEventType
{
    After3Notes,
    FirstMeetDemon,
    DestroyRitualItemCanKillDemon,
    FirstItemisBurnt,
    Final,
}

[RequireComponent(typeof(AudioSource))]
public class DialogueSystem : MonoBehaviour
{
    private Transform player;
    private Text dialogueText;
    [Header("Common Setting")]
    public bool isInGame;
    public bool isDelayToStart;
    public float delayTime;
    public UnityEvent OnSentenceFinished;
    private float textAlpha;

    [Header("ActiveByPosition setting")]
    public bool isActiveByPosition;
    public float radius;
    public Color positionColor;
    private bool isEnterArea;

    [Header("ActiveByDialogueObject setting")]
    public bool isActiveByDialogueObject;
    public DialogueObject dialogueObject;

    [Header("ActiveByEvent")]
    public bool isActiveByEvent;
    public DialogueEventType type;

    [Header("Text")]
    public List<DialogueText> sentences = new List<DialogueText>();
    private int currentSentenceIndex;

    private AudioSource voiceActing;

    private void Awake()
    {
        if (isInGame) {
            player = InGameAssetManager.i.player.transform;
        }
        dialogueText = GameAssetManager.i.dialogueText;
        dialogueText.color = new Color(1, 1, 1, 0);
        for (int i = 0; i < sentences.Count; i++)
        {
            if (sentences[i].voiceLine != null) {
                sentences[i].duration = sentences[i].voiceLine.length;
            }
        }
        if (isActiveByEvent)
        {
            GameEventObserver.i.AddToEventDialogue(this);
            OnSentenceFinished.AddListener(()=>GameEventObserver.i.RemoveEventDialogue(this));
            gameObject.SetActive(false);
        }
        voiceActing = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isActiveByPosition)
        {
            PositionFunction();
        }
        else if (isActiveByDialogueObject)
        {
            OthersFunction();
        }
        else if (isActiveByEvent) {
            UpdateText();
        }
        else
        {
            Debug.LogError("Didnt assign the type of diagloue");
        }
    }

    void PlayDialogue() {
        if (!sentences[currentSentenceIndex].isPlaying)
        {
            textAlpha = 1f;
            dialogueText.color = new Color(1, 1, 1, 1);
            dialogueText.text = sentences[currentSentenceIndex].dialogueText;
            voiceActing.PlayOneShot(sentences[currentSentenceIndex].voiceLine);
            sentences[currentSentenceIndex].isPlaying = true;
        }
    }

    void UpdateText() {
        if (isDelayToStart)
        {
            if (delayTime > 0)
            {
                delayTime -= Time.deltaTime;
            }
            else
            {
                delayTime = -1;
                PlayDialogue();
            }
        }
        else {
            PlayDialogue();
        }

        if (sentences[currentSentenceIndex].isPlaying)
        {
            if (sentences[currentSentenceIndex].duration >= 0)
            {
                sentences[currentSentenceIndex].duration -= Time.deltaTime;
            }
            else
            {
                if (currentSentenceIndex < sentences.Count - 1)
                {
                    currentSentenceIndex += 1;
                }
                else
                {
                    textAlpha -= Time.deltaTime;
                    dialogueText.color = new Color(1, 1, 1, textAlpha);

                    if (textAlpha <= 0) 
                    Destroy(gameObject);
                }
            }
        }
    }

    void PositionFunction() {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < radius && !isEnterArea)
        {
            isEnterArea = true;
        }

        if (isEnterArea) {
            UpdateText();
        }
    }

    void OthersFunction() {
        if (dialogueObject.isTrigger) {
            UpdateText();
        }
    }


    private void OnDrawGizmos()
    {
        if (isActiveByPosition) {
            Gizmos.color = positionColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }

    private void OnDestroy()
    {
        if (OnSentenceFinished != null) {
            OnSentenceFinished.Invoke();
        }
    }
}
