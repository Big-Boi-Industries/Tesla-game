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
        Pivot.MoveRotation(new Quaternion(0, 1, 0, 0));
        //if (BackStop) { if (Pivot.rotation.eulerAngles.y != 180) { Pivot.AddRelativeTorque(Vector3.up * 10, ForceMode.Force); } else { BackStop = false; } }
        //if (FrontStop) { if (Pivot.rotation.eulerAngles.y != 180) { Pivot.AddRelativeTorque(Vector3.up * -10, ForceMode.Force); } else { FrontStop = false; } }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            Pivot.MoveRotation(new Quaternion(0, 1, 0, 0));
            //if (gameObject.name.Contains("Back") & !FrontStop) { BackStop = true; }
            //if (gameObject.name.Contains("Front") & !BackStop) { FrontStop = true; }
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
