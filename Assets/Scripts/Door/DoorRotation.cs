using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Front;
using static Back;

public class DoorRotation : MonoBehaviour
{
    private Vector3 Pivot;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Pivot = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+1);
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0,0,0,0);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name.Contains("Player") & BackRot) 
        {
            rb.AddRelativeTorque(Vector3.up, ForceMode.Force);
            //transform.RotateAround(Pivot, Vector3.up, 50 * Time.smoothDeltaTime);
        }
        if (collision.collider.name.Contains("Player") & FrontRot)
        {
            rb.AddRelativeTorque(Vector3.up * -1, ForceMode.Force);
            //transform.RotateAround(Pivot, Vector3.up, -50 * Time.smoothDeltaTime);
        }
    }
}
