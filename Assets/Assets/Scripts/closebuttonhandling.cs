using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class closebuttonhandling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image bg;
    public Sprite iconchange;
    public Sprite iconstable;
    public GameObject icon;

    public GameObject taskman;


    public void OnPointerEnter(PointerEventData eventData)
    {
        icon.GetComponent<Image>().sprite = iconchange;
        bg.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        icon.GetComponent <Image>().sprite = iconstable;
        bg.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        taskman.SetActive(false);
    }
}
