using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class StartMenu : MonoBehaviour
{
    public static bool Running;
    public static bool Continued;
    public static bool MenuOpen;
    private GameObject Startmenu;
    private GameObject QuitButton;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Startmenu = GameObject.Find("Start menu");
        QuitButton = GameObject.Find("QuitButton");
        if (Running) { Startmenu.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {
        if (newGame) { Running = true; MenuOpen = false; Startmenu.SetActive(false); newGame = false; Debug.Log("New"); }
        if (continuedGame) { Running = true; Continued = true; MenuOpen = false; continuedGame = false; Debug.Log("Cont"); }
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
