using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TeslaCoilPartPickUp;

public class BuildTeslaCoil : MonoBehaviour
{
    private bool CanBuild = false;
    public static bool Placed1 = false;
    public static bool Placed2 = false;
    public static bool Placed3 = false;
    public static bool Placed4 = false;
    private bool Built = false;
    private GameObject WorkBench;
    // Start is called before the first frame update
    void Start()
    {
        WorkBench = GameObject.Find("WorkBench");
    }

    // Update is called once per frame
    void Update()
    {
        if (Placed1 & !Built) { GameObject.Find("Tesla Coil Base (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed2 & !Built) { GameObject.Find("Tesla Coil Front Middle (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed3 & !Built) { GameObject.Find("Tesla Coil Generator (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed4 & !Built) { GameObject.Find("Tesla Coil Top (4)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Input.GetKeyDown(KeyCode.E) & CanBuild) 
        {
            try 
            {
                if (Part.name.Contains("1")) { PickedUp = false; Placed1 = true; Part.transform.rotation = new Quaternion(0, 1, 0, 0); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 0.11f, WorkBench.transform.position.z); Part = null; }
                if (Part.name.Contains("2")) { if (Placed1) { PickedUp = false; Placed2 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, 0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x + 0.3f, WorkBench.transform.position.y + 0.6f, WorkBench.transform.position.z); Part = null; } }
                if (Part.name.Contains("3")) { if (Placed1) { PickedUp = false; Placed3 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 1f, WorkBench.transform.position.z); Part = null; } }
                if (Part.name.Contains("4")) { if (Placed2) { PickedUp = false; Placed4 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x + 0.138f, WorkBench.transform.position.y + 1.6f, WorkBench.transform.position.z); Part = null; } }
            }
            catch 
            {
                Debug.Log(null);
            }
        }
        if (Placed1 & Placed2 & Placed3 & Placed4 & !Built) 
        {
            Built = true;
            GameObject.Find("Tesla Coil Base (1)").SetActive(false);
            GameObject.Find("Tesla Coil Front Middle (2)").SetActive(false);
            GameObject.Find("Tesla Coil Generator (3)").SetActive(false);
            GameObject.Find("Tesla Coil Top (4)").SetActive(false);
            GameObject.Find("TeslaCoil").transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 0.621f, WorkBench.transform.position.z);        
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name == "WorkBench") 
        {
            CanBuild = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "WorkBench")
        {
            CanBuild = false;
        }
    }
}
