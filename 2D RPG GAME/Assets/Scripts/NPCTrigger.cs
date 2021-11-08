using System;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public DialogueHolder dialogueHolders;
    private static int index;

    private GroupedDialogue groupedDialogue;

    private void Start()
    {
        groupedDialogue = FindObjectOfType<GroupedDialogue>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            groupedDialogue.TriggerNextDialogue();
            GetComponent<BoxCollider2D>().enabled = false;
            GameManager.instance.pauseGame = true;
            UIManager.instance.SetDialoguePanel(true);
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogueHolders);
    }
}
