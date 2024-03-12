using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;
    public FlagHandler flags;

    public void TriggerDialogue()
    {
        flags.dialogstarted = true;
        manager.startDialogue(dialogue);
        
    }


}
