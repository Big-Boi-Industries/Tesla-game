using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DoorRotation;

public class Doorstop : MonoBehaviour
{
    private Rigidbody Pivot;
    public static bool Closing;
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
            if (gameObject.name.Contains("Back") & !Closed) { Pivot.angularVelocity = Vector3.zero; Pivot.AddRelativeTorque(Vector3.up * 1000, ForceMode.Impulse); Closed = true; }
            if (gameObject.name.Contains("Front") & !Closed) { Pivot.angularVelocity = Vector3.zero;  Pivot.AddRelativeTorque(Vector3.up * -1000, ForceMode.Impulse); Closed = true; }
        }
    }
}
