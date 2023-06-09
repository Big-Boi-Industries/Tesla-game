using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RandomSpawnLocations;

public class Unstuck : MonoBehaviour
{
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
        if (other.name.Contains("Tesla")) 
        {
            if (other.name.Contains("1")) { respawn(GameObject.Find("Tesla Coil Base (1)")); }
            if (other.name.Contains("2")) { respawn(GameObject.Find("Tesla Coil Front Middle (2)")); }
            if (other.name.Contains("3")) { respawn(GameObject.Find("Tesla Coil Generator (3)")); }
            if (other.name.Contains("4")) { respawn(GameObject.Find("Tesla Coil Top (4)")); }
        }
    }
}
