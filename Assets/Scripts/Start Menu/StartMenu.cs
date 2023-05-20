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
        if (Running) { Startmenu.SetActive(false); NewGameButton.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {
        if (newGame) { Running = true; MenuOpen = false; Startmenu.SetActive(false); newGame = false; Debug.Log("New"); }
        if (continuedGame) { Running = true; Continued = true; MenuOpen = false; Startmenu.SetActive(false); continuedGame = false; Debug.Log("Cont"); }
        try
        {
            if (Running & !hasRun) { NewGameButton.SetActive(false); hasRun = true; }
        }
        catch { Debug.Log("Error"); }
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
