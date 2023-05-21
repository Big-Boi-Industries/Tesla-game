using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StartMenu;

public class PlayerMovement : MonoBehaviour
//Requires Main Camera to be a child of this object
{
    private GameObject Camera;
    public float Speed = 25.0f; //how fast the player moves
    public float MaxSpeed = 5.0f; //terminal walking pace
    public float SprintSpeed = 8.0f; //how fast the player sprints
    public float MaxSprintSpeed = 6.0f; //terminal sprint speed
    public float CameraSensitivity = 150.0f; //how sensetive the camera is
    private float yRot = 0;
    public float JumpHight = 1.0f; //how high the player can jump
    private Vector2 Velocity;
    private bool CanJump;
    private bool Down;
    private bool Up;
    private RaycastHit hit;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera"); //sets camera variable to the main camera game object
        rb = gameObject.GetComponent<Rigidbody>(); //gets the rigidbody attached to the player
    }
    void FixedUpdate() // called every physics update
    {
        if (Running) 
        {
            Move(); //moves the player
            ClampVelocity(); //makes sure the player dosn't move to fast
            CameraMotion(); //moves the camera
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Running)
        {
            Cursor.visible = false; //hides cursor while playing
            Cursor.lockState = CursorLockMode.Locked; //locks cursor to the centre of the game window
        }
        else
        {
            Cursor.visible = true; //hides cursor while playing
            Cursor.lockState = CursorLockMode.Confined; //locks cursor to the centre of the game window
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.02f)) //raycasts downwards from the players centre 1.02 units and checks if an object is there
        {
            if (hit.transform.name.Contains("Floor")) { CanJump = true; } //if there is an object and it is a floor object then the player can jump
        }
        else { CanJump = false; } // if the raycast didn't hit an object they the player cannot jump
    }
    void CameraMotion()
    {
        if (Input.GetAxis("Mouse X") != 0) //checks if you are moving the mouse to the right
        {
            rb.AddRelativeTorque(new Vector3(0, Input.GetAxis("Mouse X") * CameraSensitivity * 30 * Time.smoothDeltaTime, 0), ForceMode.VelocityChange); //rotates the player using physics without taking into account mass by CameraSensitivity units/second in the direction the mouse is moved along the x axis
        }
        yRot = Mathf.Clamp(yRot + (Input.GetAxis("Mouse Y") * CameraSensitivity),-60f,60f);
        Camera.transform.localRotation = Quaternion.Euler(-yRot, -90, 0);
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) & !Input.GetKey(KeyCode.LeftShift)) //checks if the player is pressing a move key and not holding shift
        {
            rb.AddRelativeForce(new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized * Speed * Time.smoothDeltaTime, ForceMode.Impulse); //moves the player at walking speed
        }
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.LeftShift)) //checks if the player is pressing a move key and is holding shift
        {
            rb.AddRelativeForce(new Vector3(-Input.GetAxisRaw("Vertical"), 0, Input.GetAxisRaw("Horizontal")).normalized * SprintSpeed * Time.smoothDeltaTime, ForceMode.Impulse); //moves the player at running speed
        }
        if (!Input.GetKey(KeyCode.W) & !Input.GetKey(KeyCode.S) & !Input.GetKey(KeyCode.A) & !Input.GetKey(KeyCode.D)) { rb.velocity = new Vector3(0, rb.velocity.y, 0); } //if no movement keys are held the player stops
        if (Input.GetKey(KeyCode.Space) & CanJump) { rb.AddRelativeForce(new Vector3(0, JumpHight, 0), ForceMode.Impulse); } //if the space key is pressed and the player can jump an upwards force is applied
    }
    void ClampVelocity() 
    {
        if (!Input.GetKey(KeyCode.LeftShift)) //checks if left shift is not pressed down 
        { 
            Velocity = Vector2.ClampMagnitude(new Vector2(rb.velocity.x,rb.velocity.z), MaxSpeed); //clamps the magnitued of the rigidbodyes x and z velocities to be below MaxSpeed and stores them
            rb.velocity = new Vector3(Velocity.x, rb.velocity.y, Velocity.y); //sets the player velocity to the clamped x and z and dosn't alter the y   
        }
        else //if left shift is pressed down
        {
            Velocity = Vector2.ClampMagnitude(new Vector2(rb.velocity.x, rb.velocity.z), MaxSprintSpeed); //clamps the magnitued of the rigidbodyes x and z velocities to be below MaxSprintSpeed and stores them
            rb.velocity = new Vector3(Velocity.x, rb.velocity.y, Velocity.y); //sets the player velocity to the clamped x and z and dosn't alter the y 
        }
    }
}
