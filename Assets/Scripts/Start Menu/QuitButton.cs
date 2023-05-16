using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StartMenu;

public class QuitButton : MonoBehaviour
{
    private Button Button;
    // Start is called before the first frame update
    void Start()
    {
        Button = gameObject.GetComponent<Button>();
        Button.onClick.AddListener(OnClick);
    }
    void OnClick() 
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
