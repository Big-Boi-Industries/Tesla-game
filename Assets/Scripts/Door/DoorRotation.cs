using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Front;
using static Back;
using static Doorstop;

public class DoorRotation : MonoBehaviour
{
    private Rigidbody rb;
    private bool Opening;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name.Contains("Player") & BackRot & CanMove &!Opening)
        {
            rb.AddRelativeTorque(Vector3.up * 25, ForceMode.Force);
        }
        if (collision.collider.name.Contains("Player") & FrontRot & CanMove & !Opening)
        {
            rb.AddRelativeTorque(Vector3.up * -25, ForceMode.Force);
        }
        if (collision.collider.name.Contains("Player") & Input.GetKey(KeyCode.E))
        {
            Opening = true;
            if (FrontStop) { rb.transform.Rotate(0, -5, 0); rb.AddRelativeTorque(Vector3.up * -1.5f, ForceMode.Impulse); }
            if (BackStop) { rb.transform.Rotate(0, 5, 0); rb.AddRelativeTorque(Vector3.up * 1.5f, ForceMode.Impulse); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Opening = false;
    }
}
