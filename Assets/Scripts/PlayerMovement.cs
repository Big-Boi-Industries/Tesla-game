using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementModifier = 0.1f;
    [SerializeField] float jumpModifier = 6f;
    
    Rigidbody rb;
    Transform transform;
    [SerializeField] Transform cameraTransform;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    bool cursorVisibility = false;
    [SerializeField] float mouseSensitivityX = 4f;
    [SerializeField] float mouseSensitivityY = 4f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hi = Input.GetAxisRaw("Horizontal"); // Horizontal Momvement Variable
        float vi = Input.GetAxisRaw("Vertical"); // Vertical Movement Variable

        rb.AddRelativeForce(new Vector3(hi * movementModifier, rb.velocity.y, vi * movementModifier).normalized, ForceMode.Impulse); // Allows the basic movement of the character, not currently allowing for jump.
        if (Input.GetButtonDown("Jump") && isGrounded()) // Checks that the user has pressed jump and that they arje on the ground.
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpModifier, rb.velocity.z);
        }

        if (rb.position.y <= -50f)
        {
            rb.position = new Vector3(0, 1.5f, 0);
        }

        float turn = Input.GetAxis("Mouse X") * mouseSensitivityX;
        transform.Rotate(new Vector3(0, turn, 0), Space.Self);

        float updown = Input.GetAxis("Mouse Y") * mouseSensitivityY;
        cameraTransform.rotation = new Quaternion(clampTo(cameraTransform.rotation.x + updown, 40, -40), 0, 0, 0);
        Debug.Log(clampTo(cameraTransform.rotation.x + updown, -40f, 40f).ToString());
        

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = cursorVisibility;
    }

    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    float clampTo(float numberToClamp, float min, float max)
    {
        Debug.Log(numberToClamp.ToString());
        if(numberToClamp <= min)
        {
            return min;
        } else if(numberToClamp > max)
        {
            return max;
        } else
        {
            return numberToClamp;
        }
        
    }
}
