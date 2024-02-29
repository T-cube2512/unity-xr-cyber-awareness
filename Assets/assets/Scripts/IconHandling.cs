using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IconHandling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image img;
    public GameObject desktop;
    public Sprite virusbg;
    public Color noclickcol = new Color(1, 1, 1, 0);
    public Color hovcol = new Color(1, 1, 1, 0.3f);
    public Color clickcol = new Color(1, 1, 1, 0.7f);

    public bool isVirus;
    public bool isTaskbarIcon;

    private bool clicked;
    public bool doubleClicked;
    private float clickTimeThreshold = 0.3f; // Adjust this threshold as needed
    private float lastClickTime;

    void Start()
    {
        img.color = noclickcol;
        clicked = false;
        doubleClicked = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        changeCol();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backToNormal();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float timeSinceLastClick = Time.time - lastClickTime;
        if (timeSinceLastClick <= clickTimeThreshold)
        {
            doubleClicked = true;
            // Perform double click action here
            if(doubleClicked && isVirus)
            {
                desktop.GetComponent<Image>().sprite = virusbg;
            }
        }
        else
        {
            doubleClicked = false;
            lastClickTime = Time.time;
            clickChange();
        }
    }

    public void changeCol()
    {
        img.color = hovcol;
    }

    public void backToNormal()
    {
        img.color = noclickcol;
    }

    public void clickChange()
    {
        if (!isTaskbarIcon)
        {
            if (img.color == hovcol || img.color == noclickcol)
            {
                img.color = clickcol;
                clicked = !clicked;
            }
            else
            {
                img.color = hovcol;
                clicked = !clicked;
            }
        }
    }

    private void Update()
    {
        if (clicked)
            img.color = clickcol;
    }
}
