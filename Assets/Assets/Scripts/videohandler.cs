using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videohandler : MonoBehaviour
{
    public VideoPlayer player;

    public GameObject text;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        if(player.isPrepared)
        {
            Invoke("player.Play",5.0f);
        }
    }
    void Update()
    {
        if(player.isPlaying)
        {
            text.SetActive(false);
        }
        else
        {
            text.SetActive(true);
        }
    }
}
