using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static RandomSpawnLocations;

public class Boundries : MonoBehaviour
{
    private GameObject Coil1;
    private GameObject Coil2;
    private GameObject Coil3;
    private GameObject Coil4;
    // Start is called before the first frame update
    void Start()
    {
        Coil1 = GameObject.Find("Tesla Coil Base (1)");
        Coil2 = GameObject.Find("Tesla Coil Front Middle (2)");
        Coil3 = GameObject.Find("Tesla Coil Generator (3)");
        Coil4 = GameObject.Find("Tesla Coil Top (4)");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(new Vector3(-28.5f, 9.32f, 21), new Vector3(7.5f, 3.089f, 9));
        if (!colliders.Contains(Coil1.GetComponent<Collider>())) { respawn(Coil1); }
        if (!colliders.Contains(Coil2.GetComponent<Collider>())) { respawn(Coil2); }
        if (!colliders.Contains(Coil3.GetComponent<Collider>())) { respawn(Coil3); }
        if (!colliders.Contains(Coil4.GetComponent<Collider>())) { respawn(Coil4); }
               
    }
}
