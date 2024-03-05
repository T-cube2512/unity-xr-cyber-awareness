using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{


    [SerializeField]
    public bool virusAttackedFlag;
    public bool networkShutFlag;
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

    }

    public void setTaskEndedFlag(bool x)
    { 
        taskEndedFlag = x;
        Debug.Log("task ended");

    }

    public bool getVirusAttackedFlag()
    { return virusAttackedFlag; }

    public bool getNetworkShutFlag()
    { return networkShutFlag; }

    public bool getTaskEndedFlag()
    { return taskEndedFlag; }
}
