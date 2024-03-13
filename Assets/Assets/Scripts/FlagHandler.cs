using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    public DialogueTrigger dialtrig;
    public bool dialogstarted;
    [SerializeField]
    public bool virusAttackedFlag;
    public bool networkShutFlag;
    public bool taskOpenedFlag;
    public bool taskEndedFlag;

    public void setVirusAttackedFlag(bool x)
    { 
        virusAttackedFlag = x;
        Debug.Log("virus attacked");
    }

    public void setNetworkShutFlag(bool x)
    { 
        networkShutFlag = x;
        Debug.Log("network shut");
        StartCoroutine(dialtrig.series2());

    }

    public void setTaskOpenFlag(bool x)
    {
        taskOpenedFlag = x;
        Debug.Log("task opened");
        StartCoroutine(dialtrig.series3());
    }

    public void setTaskEndedFlag(bool x)
    { 
        taskEndedFlag = x;
        Debug.Log("task ended");
        StartCoroutine(dialtrig.series4());
    }

    public bool getVirusAttackedFlag()
    { return virusAttackedFlag; }

    public bool getNetworkShutFlag()
    { return networkShutFlag; }

    public bool getTaskOpenFlag()
    { return taskOpenedFlag; }

    public bool getTaskEndedFlag()
    { return taskEndedFlag; }
}
