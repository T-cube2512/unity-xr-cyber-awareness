using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMsgs : MonoBehaviour
{
    
    public void released()
    {
        Debug.Log("Released");
    }
    public void hovered()
    {
        Debug.Log("Hovered");
    }
    public void unhovered()
    {
        Debug.Log("Unhovered");
    }
    public void selected()
    {
        Debug.Log("Selected");
    }
    public void unselected()
    {
        Debug.Log("Unselected");
    }
    public void moved()
    {
        Debug.Log("Moved");
    }
    public void canceled()
    {
        Debug.Log("Canceled");
    }
}
