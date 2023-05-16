using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public static bool Running;
    public static bool Continued;
    public static bool MenuOpen;
    private GameObject Startmenu;
    private GameObject NewGameButton;
    private GameObject QuitButton;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Startmenu = GameObject.Find("Start menu");
        NewGameButton = GameObject.Find("NewGameButton");
        QuitButton = GameObject.Find("QuitButton");
        QuitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Running & !hasRun) { NewGameButton.SetActive(false); hasRun = true; }
        if (Running) { QuitButton.SetActive(true); }
        if (Input.GetKeyDown("escape") & Running | Input.GetKeyDown("escape") & MenuOpen) 
        {
            if (MenuOpen) 
            {
                Running = true;
                MenuOpen = false; 
                Startmenu.SetActive(false); 
            }
            else {
                Running = false;
                MenuOpen = true;
                Startmenu.SetActive(true);
            }
        }
    }
}
