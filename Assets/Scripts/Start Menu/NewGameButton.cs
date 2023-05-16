using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StartMenu;

public class NewGameButton : MonoBehaviour
{
    private Button Button;
    private GameObject StartMenu;
    // Start is called before the first frame update
    void Start()
    {
        StartMenu = GameObject.Find("Start menu");
        Button = gameObject.GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }
    void OnClick() 
    {
        Running = true;
        MenuOpen = false;
        StartMenu.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
