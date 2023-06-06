using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StartMenu;

public class pauseButtons : MonoBehaviour
{
    private GameObject StartMenu;
    // Start is called before the first frame update
    void Start()
    {
        StartMenu = GameObject.Find("Start menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onContinue() 
    {
        Continued = true;
        Running = true;
        MenuOpen = false;
        StartMenu.SetActive(false);
    }
    public void onQuit() 
    {
        Application.Quit();
    }
}
