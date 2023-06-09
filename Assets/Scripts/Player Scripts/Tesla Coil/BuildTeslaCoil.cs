using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TeslaCoilPartPickUp;

public class BuildTeslaCoil : MonoBehaviour
{
    public bool CanBuild = false;
    public static bool Placed1 = false;
    public static bool Placed2 = false;
    public static bool Placed3 = false;
    public static bool Placed4 = false;
    private bool Built = false;
    private GameObject WorkBench;
    private GameObject backer2;
    private GameObject showBuild;
    // Start is called before the first frame update
    void Start()
    {
        WorkBench = GameObject.Find("WorkBench");
        showBuild = GameObject.Find("BuildAvailable");
        backer2 = GameObject.Find("Backer 2");
        showBuild.SetActive(false);
        backer2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Placed1 & !Built) { GameObject.Find("Tesla Coil Base (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed2 & !Built) { GameObject.Find("Tesla Coil Front Middle (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; GameObject.Find("Tesla Coil Front Middle (2)").transform.rotation = new Quaternion(0, 0.7071f, 0, 0.7071f); }
        if (Placed3 & !Built) { GameObject.Find("Tesla Coil Generator (3)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; GameObject.Find("Tesla Coil Generator (3)").transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); }
        if (Placed4 & !Built) { GameObject.Find("Tesla Coil Top (4)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; GameObject.Find("Tesla Coil Top (4)").transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); }
        if (Input.GetKeyDown(KeyCode.E) & CanBuild) 
        {
            try
            {
                if (Part.name.Contains("1")) { PickedUp = false; Placed1 = true; Part.transform.rotation = new Quaternion(0, 1, 0, 0); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 0.3f, WorkBench.transform.position.z + 0.3f); Part = null; }
                if (Part.name.Contains("2")) { if (Placed1) { PickedUp = false; Placed2 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, 0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x + 0.3f, WorkBench.transform.position.y + 0.8f, WorkBench.transform.position.z + 0.3f); Part = null; } }
                if (Part.name.Contains("3")) { if (Placed1) { PickedUp = false; Placed3 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 1.23f, WorkBench.transform.position.z + 0.3f); Part = null; } }
                if (Part.name.Contains("4")) { if (Placed2) { PickedUp = false; Placed4 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, -0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x + 0.138f, WorkBench.transform.position.y + 1.77f, WorkBench.transform.position.z + 0.3f); Part = null; } }
            }
            catch { }
        }
        if (Placed1 & Placed2 & Placed3 & Placed4 & !Built) 
        {
            Built = true;
            GameObject.Find("Tesla Coil Base (1)").SetActive(false);
            GameObject.Find("Tesla Coil Front Middle (2)").SetActive(false);
            GameObject.Find("Tesla Coil Generator (3)").SetActive(false);
            GameObject.Find("Tesla Coil Top (4)").SetActive(false);
            GameObject.Find("TeslaCoil").transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 0.82f, WorkBench.transform.position.z+0.3f);        
        }
        if (!PickedUp) 
        {
            showBuild.SetActive(false);
            backer2.SetActive(false);
        }
    }
    private void OnCollisionStay(Collision collider)
    {
        if (collider.collider.name == "WorkBench") 
        {
            CanBuild = true;
            try
            {
                if (Part.name.Contains("1"))
                {
                    showBuild.SetActive(true);
                    backer2.SetActive(true);
                }
                if (Part.name.Contains("2") & Placed1)
                {
                    showBuild.SetActive(true);
                    backer2.SetActive(true);
                }
                if (Part.name.Contains("3") & Placed1)
                {
                    showBuild.SetActive(true);
                    backer2.SetActive(true);
                }
                if (Part.name.Contains("4") & Placed2)
                {
                    showBuild.SetActive(true);
                    backer2.SetActive(true);
                }
            }
            catch { }
        }
    }
    private void OnCollisionExit(Collision collider)
    {
        if (collider.collider.name == "WorkBench")
        {
            CanBuild = false;
            showBuild.SetActive(false);
            backer2.SetActive(false);
        }
    }
}
