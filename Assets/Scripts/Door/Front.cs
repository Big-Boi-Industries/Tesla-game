using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front : MonoBehaviour
{
    public static bool FrontRot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player")) { FrontRot = true; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player")) { FrontRot = false; }
    }
}