using System.Collections.Generic;
using UnityEngine;

public class GroupedDialogue : MonoBehaviour
{
   public List<NPCTrigger> npcTriggers;

   public void TriggerNextDialogue()
   {
      if (npcTriggers.Count > 0)
      {
         npcTriggers[0].TriggerDialogue();
      }
     
   }

   public void RemoveIndex()
   {
      npcTriggers.RemoveAt(0);
   }

   public bool CheckIfListIsEmpty()
   {
      return npcTriggers.Count == 0;
   }
   
}
