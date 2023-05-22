using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorstop : MonoBehaviour
{
    public static bool CanMove = true;
    public static bool BackStop = false;
    public static bool FrontStop = false;
    private Rigidbody Pivot;
    // Start is called before the first frame update
    void Start()
    {
        Pivot = transform.parent.GetComponent<Rigidbody>();
        Pivot = Pivot.transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (BackStop) { if (Pivot.rotation.eulerAngles.y != 180) { Pivot.AddRelativeTorque(Vector3.up * 10, ForceMode.Force); } else { BackStop = false; } }
        //if (FrontStop) { if (Pivot.rotation.eulerAngles.y != 180) { Pivot.AddRelativeTorque(Vector3.up * -10, ForceMode.Force); } else { FrontStop = false; } }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {   
            if (gameObject.name.Contains("Back") & !FrontStop) { BackStop = true; Pivot.AddRelativeTorque(Vector3.up * 5); }
            if (gameObject.name.Contains("Front") & !BackStop) { FrontStop = true; Pivot.AddRelativeTorque(Vector3.up * -5); }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            CanMove = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            CanMove = true;
        }
    }
}
