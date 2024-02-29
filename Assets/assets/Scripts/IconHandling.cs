using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class IconHandling : MonoBehaviour ,IPointerEnterHandler, IPointerExitHandler , IPointerClickHandler
{

    public Image img;    

    public GameObject desktop;

    public Color noclickcol = new Color(1,1,1,0);
    public Color hovcol = new Color(1,1,1,0.3f);
    public Color clickcol = new Color(1,1,1,0.7f);

    private bool clicked;
    private bool doubleclicked;

    public bool isVirus;
    public bool isTaskbarIcon;




    void Start()
    {
        img.color =  noclickcol;
        clicked = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        changeCol();
        Debug.Log("hover enter");

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        backtonormal();
        Debug.Log("hover stop");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickchange();
        Debug.Log("clicked");
    }


    public void changeCol() {
        img.color = hovcol;
    }

    public void backtonormal() {
        img.color = noclickcol;
    }

    public void clickchange(){
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

    private void Update() {
        if(clicked) img.color = clickcol;
        


    }
    
}
