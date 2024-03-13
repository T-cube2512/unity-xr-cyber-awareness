using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class IconHandling : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public FlagHandler FlagHandler;


    public Image img;
    public Image icon;

    public Sprite virusicon;
    public GameObject desktop;
    public GameObject messagebox;
    public GameObject wifiscreen;
    public GameObject taskmanagerscreen;
    public GameObject ocwifi;



    public GameObject virustask;
    public Sprite virusbg;
    public Text wifitext;
    public Sprite wifichange;
    public GameObject wifistable;
    public Color noclickcol = new Color(1, 1, 1, 0);
    public Color hovcol = new Color(1, 1, 1, 0.3f);
    public Color clickcol = new Color(1, 1, 1, 0.7f);

    public bool isSoftwareApp;
    public bool isVirus;
    public bool isTaskManager;
    public bool isTaskbarIcon;
    public bool isWifi;
    public bool isWifistable;


    public bool virusAttackedFlag;
    public bool networkShutFlag;
    public bool taskEndedFlag;


    public bool clicked;
    public bool doubleClicked;
    private float clickTimeThreshold = 0.3f; 
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

            if(doubleClicked && isVirus)
            {
                FlagHandler.setVirusAttackedFlag(true);
                messagebox.SetActive(true);



            }

            if (doubleClicked && isTaskManager)
            {
                FlagHandler.setTaskOpenFlag(true);
                taskmanagerscreen.SetActive(true);
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

        if (clicked && isWifi)
        {
            wifiscreen.SetActive(true);
            clicked = !clicked;
        }
        else if (!clicked && isWifi)
        {
            wifiscreen.SetActive(false);
            clicked = !clicked;
        }

        

        if(clicked && isWifistable)
        {
            wifitext.color = Color.black;
            wifistable.GetComponent<Image>().sprite = wifichange;
            ocwifi.SetActive(false);
            FlagHandler.setNetworkShutFlag(true);
            

        }


    }

    public void dissappearocwifi()
    {
        ocwifi.SetActive(false);
        FlagHandler.setNetworkShutFlag(true);
    }

 

    private void Update()
    {
        if (clicked)
            img.color = clickcol;

        if(FlagHandler.getVirusAttackedFlag())
        {
            desktop.GetComponent<Image>().sprite = virusbg;
            //Debug.Log("changed wp");
            if(isSoftwareApp)
            {
                icon.GetComponent<Image>().sprite = virusicon;
            //Debug.Log("changed icon" +gameObject.name);


            }
            
        }
        
        

    }

    public void endtask()
    {
        virustask.SetActive(false);
        FlagHandler.setTaskEndedFlag(true);
        FlagHandler.setVirusAttackedFlag(false);
        
    }
}
