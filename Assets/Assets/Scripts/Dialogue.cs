using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;


[System.Serializable]
public class Dialogue 
{
    [TextArea(3,10)]
    public string[] sentences;
    public AudioClip[] voicelines;

    public VideoClip[] tutorials;

    
    
}
