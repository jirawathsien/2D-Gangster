using System;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    public DialogueHolder dialogueHolders;
    
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
