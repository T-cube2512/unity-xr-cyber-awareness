using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloHandler : MonoBehaviour
{
    public FlagHandler FlagHandler;

    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (FlagHandler.getVirusAttackedFlag())
        {
            gameObject.SetActive(true);
        }
    }
}
