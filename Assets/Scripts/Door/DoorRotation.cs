using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Front;
using static Back;

public class DoorRotation : MonoBehaviour
{
    private Rigidbody rb;
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
        if (collision.collider.name.Contains("Player") & BackRot)
        {
            rb.AddRelativeTorque(Vector3.up, ForceMode.Force);
        }
        if (collision.collider.name.Contains("Player") & FrontRot)
        {
            rb.AddRelativeTorque(Vector3.up * -1, ForceMode.Force);
        }
    }
}
