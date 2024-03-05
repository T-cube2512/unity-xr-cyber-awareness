using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MessageHandler : MonoBehaviour
{
    public GameObject message;
    public FlagHandler FlagHandler;
    public GameObject textfile;


    public void closeandopentext()
    {
        textfile.SetActive(true);
        message.SetActive(false); 
    }
}
