using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorRotation;

public class Doorstop : MonoBehaviour
{
    public static bool BackStop = false;
    public static bool FrontStop = false;
    public static bool Closing = false;
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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            if (gameObject.name.Contains("Back") & !FrontStop & !Closed) { Pivot.angularVelocity = Vector3.zero;  BackStop = true; Pivot.AddRelativeTorque(Vector3.up * 1000, ForceMode.Impulse); Closing = true; }
            if (gameObject.name.Contains("Front") & !BackStop & !Closed) { Pivot.angularVelocity = Vector3.zero;  FrontStop = true; Pivot.AddRelativeTorque(Vector3.up * -1000, ForceMode.Impulse); Closing = true; }
        }
    }
}
