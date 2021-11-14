using System;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public DialogueHolder dialogueHolders;

    public bool isNPC;
    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isNPC && other.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            other.attachedRigidbody.velocity = Vector2.zero;
            other.gameObject.GetComponent<Animator>().SetBool("IsWalking", false);
            StartDialogue();
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
