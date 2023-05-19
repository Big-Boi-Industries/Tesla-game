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
    private GameObject WorkBench;
    // Start is called before the first frame update
    void Start()
    {
        WorkBench = GameObject.Find("WorkBench");
    }

    // Update is called once per frame
    void Update()
    {
        if (Placed1) { GameObject.Find("Tesla Coil Base (1)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed2) { GameObject.Find("Tesla Coil Front Middle (2)").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Placed3) { GameObject.Find("Tesla Coil test part 3").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; }
        if (Input.GetKeyDown(KeyCode.E) & CanBuild) 
        {
            if (Part.name.Contains("1")) { PickedUp = false; Placed1 = true; Part.transform.rotation = new Quaternion(0, 1, 0, 0); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 0.75f, WorkBench.transform.position.z); Part = null; }
            if (Part.name.Contains("2")) { PickedUp = false; Placed2 = true; Part.transform.rotation = new Quaternion(0, 0.7071f, 0, 0.7071f); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 1.25f, WorkBench.transform.position.z); Part = null; }
            if (Part.name.Contains("3")) { PickedUp = false; Placed3 = true; Part.transform.rotation = new Quaternion(0, 0, 0, 0); Part.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll; Part.transform.position = new Vector3(WorkBench.transform.position.x, WorkBench.transform.position.y + 1.75f, WorkBench.transform.position.z); Part = null; }
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
