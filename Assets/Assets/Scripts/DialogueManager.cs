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
    public GameObject videoplayerGO;

    public FlagHandler flagHandler;
    private Queue<string> sentences;
    private Queue<AudioClip> voicelines;
    private Queue<VideoClip> tutorialvid;

    public string currentsentence;
    public AudioClip currentaudio;

    private void Start()
    {
        
        sentences = new Queue<string>();
        voicelines = new Queue<AudioClip>();
        tutorialvid = new Queue<VideoClip>();
        videoplayerGO.SetActive(false);
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
        foreach (VideoClip vid in dialogue.tutorials)
        {
            tutorialvid.Enqueue(vid);
        }

        DisplayNextSentence(false);
    }

    public void DisplayNextSentence(bool withvid)
    {
        if(sentences.Count == 0 ) 
        {
            EndDialogue();
            return;
        }



        string sentence = sentences.Dequeue();
        currentsentence = sentence;
        AudioClip voice = voicelines.Dequeue();
        currentaudio = voice;
        audioSource.clip = voice;
        if (withvid)
        {
            VideoClip videoClip = tutorialvid.Dequeue();
            videoPlayer.clip = videoClip;
        }
       
        //float fin = audioSource.clip.length;

        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence,withvid));

        
        
    }

    IEnumerator TypeSentence(string sentence, bool withvid)
    {
        audioSource.Play();
        float fin = audioSource.clip.length;
        if (withvid)
        {
            videoplayerGO.SetActive(true);
            videoPlayer.Play();
        }
        else
        {
            videoplayerGO.SetActive(false);

            videoPlayer.Stop();
        }
        
        //Debug.Log("playing audio " + audioSource.clip.ToString());
        DialogText.text = "";
        foreach (char letters in sentence.ToCharArray())
        {
            DialogText.text += letters;
            yield return null;
        }
       
            yield return new WaitForSeconds(fin);

    }
    

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
}
