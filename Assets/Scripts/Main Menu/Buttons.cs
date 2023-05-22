using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GlobalVariables;

public class Buttons : MonoBehaviour
{

    private bool keyboardShortcutsMenu = false;
    [SerializeField] private GameObject controlsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        controlsDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartGame()
    {
        newGame = true;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void onContinueGame()
    {
        continuedGame = true;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void onKeyboardShortcuts()
    {
        if(!keyboardShortcutsMenu)
        {
            controlsDisplay.SetActive(true);
            keyboardShortcutsMenu = true;
        } else
        {
            controlsDisplay.SetActive(false);
            keyboardShortcutsMenu = false;
        }
    }
}
