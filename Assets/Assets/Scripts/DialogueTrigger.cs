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
        StartCoroutine(series1());
        
    }

    IEnumerator series1()
    {
        yield return new WaitForSeconds(manager.currentaudio.length);
        manager.DisplayNextSentence(false);
        yield return new WaitForSeconds(manager.currentaudio.length + 4.0f);
        manager.DisplayNextSentence(false);
        yield return new WaitForSeconds(manager.currentaudio.length);
        manager.DisplayNextSentence(true);

    }

    public IEnumerator series2()
    {
        manager.DisplayNextSentence(false);
        yield return new WaitForSeconds(manager.currentaudio.length);
        manager.DisplayNextSentence(true);
    }

    public IEnumerator series3()
    {
        manager.DisplayNextSentence(false);
        yield return new WaitForSeconds(manager.currentaudio.length);
        manager.DisplayNextSentence(true);
    }

    public IEnumerator series4()
    {
        manager.DisplayNextSentence(false);
        return null;
    }



}
