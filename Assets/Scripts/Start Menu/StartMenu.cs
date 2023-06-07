using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class StartMenu : MonoBehaviour
{
    public static bool Running;
    public static bool Tutorial;
    public static bool Continued;
    public static bool MenuOpen;
    private GameObject Startmenu;
    private GameObject TutorialUI;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Startmenu = GameObject.Find("Start menu");
        TutorialUI = GameObject.Find("Tutorial");
        if (Running) { Startmenu.SetActive(false); }
        TutorialUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (newGame) { Tutorial = true; MenuOpen = false; Startmenu.SetActive(false); newGame = false; Debug.Log("New"); }
        if (Input.GetKey(KeyCode.W) & Tutorial | Input.GetKey(KeyCode.A) & Tutorial | Input.GetKey(KeyCode.S) & Tutorial | Input.GetKey(KeyCode.D) & Tutorial) { Tutorial = false; TutorialUI.SetActive(false); Running = true; }
        if (continuedGame) { Running = true; Continued = true; MenuOpen = false; TutorialUI.SetActive(false); Startmenu.SetActive(false); continuedGame = false; Debug.Log("Cont"); }
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
