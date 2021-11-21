using System;
using DG.Tweening;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public DialogueHolder dialogueHolders;

    public bool isNPC;

    public bool is3rdRoomNpc;
    public BoxCollider2D col;
    public BoxCollider2D battleCollider2d;

    public RectTransform questWindow;
    public RectTransform questWindowToClose;
    public GameObject room4Door;

    private void Start()
    {
        if (is3rdRoomNpc && questWindow != null)
        {
            DialogueManager.instance.OnDialogueFinish += () =>
            {
                questWindow.gameObject.SetActive(true);
                questWindow.DOAnchorPosX(0f, 0.5f).SetEase(Ease.OutBack);
                
                if (questWindowToClose != null)
                {
                    room4Door.SetActive(true);
                    questWindowToClose.gameObject.SetActive(false);
                }
            };
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isNPC && other.gameObject.CompareTag("Player"))
        {
            DialogueManager.instance.is3rdRoomNPC = true;
            
            GetComponent<Collider2D>().enabled = false;
            other.attachedRigidbody.velocity = Vector2.zero;
            other.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
            StartDialogue();

            if (is3rdRoomNpc)
            {
                if (col != null)
                {
                    col.enabled = true;
                    battleCollider2d.enabled = true;
                }
            }
            
        }
    }

    public void StartDialogue()
    {
        GameManager.instance.pauseGame = true;
        UIManager.instance.SetDialoguePanel(true);
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogueHolders);
    }
}
