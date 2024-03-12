using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class DialogueManager : MonoBehaviour
{

    public Text DialogText;
    public Animator animator;
    public AudioSource audioSource;
    public VideoPlayer videoPlayer;
    public FlagHandler flagHandler;
    private Queue<string> sentences;
    private Queue<AudioClip> voicelines;


    private void Start()
    {
        
        sentences = new Queue<string>();
        voicelines = new Queue<AudioClip>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        animator.SetBool("isOpen", true);

        foreach(string sentence in dialogue.sentences)
        { 
            sentences.Enqueue(sentence); 
        }
        foreach (AudioClip voice in dialogue.voicelines)
        {
            voicelines.Enqueue(voice);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 ) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        AudioClip voice = voicelines.Dequeue();
        audioSource.clip = voice;

        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence));

        
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        audioSource.Play();
        

        //Debug.Log("playing audio " + audioSource.clip.ToString());
        DialogText.text = "";
        foreach (char letters in sentence.ToCharArray())
        {
            DialogText.text += letters;
            yield return null;
        }
    }
    
    public void playvideo(VideoClip video)
    {
        videoPlayer.clip = video; 
        videoPlayer.isLooping = true;
        videoPlayer.Play();
    }

    public void stopvideo()
    {
        videoPlayer.Stop();
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
