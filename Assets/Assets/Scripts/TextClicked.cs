using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class TextClicked : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Text text;
    public GameObject textobject;
    public GameObject VideoPlayer;
    public Color hovercolor;
    public Color regularcolor;

    public FlagHandler FlagHandler;
    public GameObject messagebox;
    public DialogueTrigger DialogTrigger;


    public GameObject holoprojector;
    public GameObject gojosatoru;

    private void Start()
    {
        //textobject.SetActive(false);
        text.color = regularcolor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = hovercolor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = regularcolor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        VideoPlayer.SetActive(false);
        Invoke("changescenedesktop",3.0f);
    }


    public void changescenedesktop()
    {
        FlagHandler.setVirusAttackedFlag(true);
        Invoke("showmsgbox", 2.0f);

        Invoke("activateholo", 5.0f);
    }

    public void showmsgbox()
    {
        messagebox.SetActive(true);
    }
    public void activateholo()
    {
        holoprojector.SetActive(true);
        gojosatoru.SetActive(true);
        DialogTrigger.TriggerDialogue();
    }


}
