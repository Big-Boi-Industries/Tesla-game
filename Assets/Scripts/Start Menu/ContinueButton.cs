using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static StartMenu;

public class ContinueButton : MonoBehaviour
{
    private Button Button;
    private GameObject StartMenu;
    // Start is called before the first frame update
    void Start()
    {
        Button = gameObject.GetComponent<Button>();
        StartMenu = GameObject.Find("Start menu");
        Button.onClick.AddListener(Clicked);
    }
    private void Clicked() 
    {
        Continued = true;
        Running = true;
        MenuOpen = false;
        StartMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
