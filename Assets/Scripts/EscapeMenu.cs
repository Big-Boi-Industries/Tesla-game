using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{

    bool EscapeActive = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(EscapeActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (EscapeActive)
            {
                EscapeActive = false;
            } else
            {
                EscapeActive = true;
            }
        }
    }
}
