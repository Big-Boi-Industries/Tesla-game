using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildTeslaCoil;
using static StartMenu;

public class Win : MonoBehaviour
{
    private GameObject WinUI;
    public static bool GameOver = false;
    private bool HasRun;
    // Start is called before the first frame update
    void Start()
    {
        WinUI = GameObject.Find("GameWon");
        HasRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Placed1 & Placed2 & Placed3 & Placed4 & !HasRun) 
        {
            GameOver = true;
            WinUI.SetActive(true);
            Running = false;
            if (Input.GetKey(KeyCode.Return)) { WinUI.SetActive(false); Running = true; HasRun = true; }
        } 
        
    }
}
