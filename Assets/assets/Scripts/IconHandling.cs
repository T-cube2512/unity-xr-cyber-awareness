using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class IconHandling : MonoBehaviour
{

    public Image img;    

    public Color noclickcol = new Color(1,1,1,0);
    public Color hovcol = new Color(1,1,1,0.3f);
    public Color clickcol = new Color(1,1,1,0.7f);




    void Start()
    {
        img.color =  noclickcol;
    }


public void changeCol() {
        img.color = hovcol;
    }

    public void backtonormal() {
        img.color = noclickcol;
    }

    public void clickchange(){
        if(img.color == hovcol || img.color == noclickcol){
        img.color = clickcol;}
        else
        img.color=hovcol;
    }
    
}
