using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;
using static Win;

public class StartMenu : MonoBehaviour
{
    public static bool Running;
    public static bool Tutorial;
    public static bool Continued;
    public static bool MenuOpen;
    private GameObject Startmenu;
    private GameObject TutorialUI;
    private GameObject WinUI;
    private bool hasRun = false;
    // Start is called before the first frame update
    void Start()
    {
        Startmenu = GameObject.Find("Start menu");
        TutorialUI = GameObject.Find("Tutorial");
        WinUI = GameObject.Find("GameWon");
        if (Running) { Startmenu.SetActive(false); }
        TutorialUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (newGame) { GameOver = false; Tutorial = true; MenuOpen = false; Startmenu.SetActive(false); newGame = false; WinUI.SetActive(false); Debug.Log("New"); }
        if (Input.GetKey(KeyCode.W) & Tutorial | Input.GetKey(KeyCode.A) & Tutorial | Input.GetKey(KeyCode.S) & Tutorial | Input.GetKey(KeyCode.D) & Tutorial) { Tutorial = false; TutorialUI.SetActive(false); Running = true; }
        if (continuedGame) { Running = true; Continued = true; MenuOpen = false; WinUI.SetActive(false); TutorialUI.SetActive(false); Startmenu.SetActive(false); continuedGame = false; Debug.Log("Cont"); }
        if (Input.GetKeyDown("escape") & Running | Input.GetKeyDown("escape") & MenuOpen) 
        {
            if (MenuOpen) 
            {
                Cursor.visible = false; //hides cursor while playing
                Cursor.lockState = CursorLockMode.Locked; //locks cursor to the centre of the game window
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
