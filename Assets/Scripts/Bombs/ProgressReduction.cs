using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildTeslaCoil;
using static RandomSpawnLocations;

public class ProgressReduction : MonoBehaviour
{
    private bool done = false;
    private int PartNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("WorkBench"))
        {
            done = true;
            if (Placed1 & !Placed2 & !Placed3) { Placed1 = false; GameObject.Find("Tesla Coil Base (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Base (1)"));}
            if (Placed2 & Placed3 & !done) 
            {
                PartNo = UnityEngine.Random.Range(2,3);
                Debug.Log(PartNo);
                if (PartNo == 2) { Debug.Log("2"); Placed2 = false; GameObject.Find("Tesla Coil Front Middle (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Front Middle (2)")); done = true; }
                if (PartNo == 3) { Debug.Log("3"); Placed3 = false; GameObject.Find("Tesla Coil Generator (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Generator (3)")); done = true; }
            }
            if (Placed2 & !Placed3 & !Placed4 & !done) { Debug.Log("2!3"); Placed2 = false; GameObject.Find("Tesla Coil Front Middle (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Front Middle (2)")); done = true; }
            if (!Placed2 & Placed3 & !done) { Debug.Log("3!2"); Placed3 = false; GameObject.Find("Tesla Coil Generator (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Generator (3)")); done = true; }
            if (Placed1 & Placed2 & !Placed3 & Placed4) { Placed4 = false; GameObject.Find("Tesla Coil Top (4)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; respawn(GameObject.Find("Tesla Coil Top (4)")); }
        }
    }
}
