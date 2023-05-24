using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Doorstop;

public class Front : MonoBehaviour
{
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
    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Player") & !Closing) { Pivot.AddRelativeTorque(Vector3.up * -1000, ForceMode.Force); }
    }
}