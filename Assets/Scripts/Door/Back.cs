using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Doorstop;

public class Back : MonoBehaviour
{
    private Rigidbody Pivot;
    private bool CanRotate;
    // Start is called before the first frame update
    void Start()
    {
        Pivot = transform.parent.GetComponent<Rigidbody>();
        Pivot = Pivot.transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRotate & !Closing) { Pivot.AddRelativeTorque(Vector3.up * 1000, ForceMode.Force); }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player") & !Closing) { CanRotate = true; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Player")) { CanRotate = false; }
    }
}