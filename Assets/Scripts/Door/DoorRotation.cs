using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Front;
using static Back;
using static Doorstop;

public class DoorRotation : MonoBehaviour
{
    public float DoorRotationSpeed = 2.0f;
    private Rigidbody rb;
    public static bool Closed;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(BackRot);
        rb.angularVelocity = new Vector3(0, Mathf.Clamp(rb.angularVelocity.y, -DoorRotationSpeed, DoorRotationSpeed), 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name.Contains("Player") & BackRot)
        {
            rb.AddRelativeTorque(Vector3.up * 1000, ForceMode.Force);
        }
        if (collision.collider.name.Contains("Player") & FrontRot)
        {
            rb.AddRelativeTorque(Vector3.up * -1000, ForceMode.Force);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Closed Locator") & !Closed) { Closed = true; rb.angularVelocity = Vector3.zero; FrontStop = false; BackStop = false; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Closed Locator") & Closed) { Closed = false; }
    }
}
    
