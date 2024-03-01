using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClockDigital : MonoBehaviour
{
    public Text textClock;
    public Text Datetext;



    void Update()
    {
        DateTime time = DateTime.Now;
        string dateString = time.ToString("d/M/yyyy");

       
        string timeString = time.ToString("h:mm tt");
        Datetext.text = dateString;
        textClock.text = timeString;
    }

}