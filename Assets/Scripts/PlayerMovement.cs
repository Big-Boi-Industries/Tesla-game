using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementModifier = 5f;
    [SerializeField] float jumpModifier = 6f;
    Rigidbody rb;
    Transform transform;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hi = Input.GetAxis("Horizontal"); // Horizontal Momvement Variable
        float vi = Input.GetAxis("Vertical"); // Vertical Movement Variable

        rb.AddRelativeForce(new Vector3(hi * movementModifier, rb.velocity.y, vi * movementModifier)); // Allows the basic movement of the character, not currently allowing for jump.
        if (Input.GetButtonDown("Jump") && isGrounded()) // Checks that the user has pressed jump and that they arje on the ground.
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpModifier, rb.velocity.z);
        }

        float turn = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, turn, 0), Space.Self);
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
