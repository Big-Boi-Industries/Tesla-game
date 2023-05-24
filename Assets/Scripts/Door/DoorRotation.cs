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
    private GameObject Front;
    private GameObject Back;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = new Vector3(0, Mathf.Clamp(rb.angularVelocity.y, -DoorRotationSpeed, DoorRotationSpeed), 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Closed Locator") & !Closed) { Closed = true; rb.angularVelocity = Vector3.zero; FrontStop = false; BackStop = false; Closing = false; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Closed Locator") & Closed) { Closed = false; }
    }
}
    
