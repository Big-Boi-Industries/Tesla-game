using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BuildTeslaCoil;

public class TeslaCoilPartPickUp : MonoBehaviour
{
    private bool PickUp = false;
    private GameObject Holder;
    private GameObject Player;
    public static bool PickedUp;
    public static GameObject Part;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Holder = GameObject.Find("Hold");
    }

    // Update is called once per frame
    void Update()
    {
        if (PickedUp) 
        {
            Part.transform.rotation = new Quaternion(0, Player.transform.rotation.y, 0 , Player.transform.rotation.w);
            Part.transform.position = new Vector3(Holder.transform.position.x, Holder.transform.position.y, Holder.transform.position.z);
            Part.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.Q)) 
            {
                Part = null;
                PickedUp = false;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.name.Contains("Tesla Coil"))
        {
            if (collision.collider.name.Contains("1") & !Placed1) 
            {
                PickUp = true;
                if (PickUp & Input.GetKey(KeyCode.E) & !PickedUp)
                {
                    Part = collision.gameObject;
                    PickedUp = true;
                }
            }
            if (collision.collider.name.Contains("2") & !Placed2)
            {
                PickUp = true;
                if (PickUp & Input.GetKey(KeyCode.E) & !PickedUp)
                {
                    Part = collision.gameObject;
                    PickedUp = true;
                }
            }
            if (collision.collider.name.Contains("3") & !Placed3)
            {
                PickUp = true;
                if (PickUp & Input.GetKey(KeyCode.E) & !PickedUp)
                {
                    Part = collision.gameObject;
                    PickedUp = true;
                }
            }
            if (collision.collider.name.Contains("4") & !Placed4)
            {
                PickUp = true;
                if (PickUp & Input.GetKey(KeyCode.E) & !PickedUp)
                {
                    Part = collision.gameObject;
                    PickedUp = true;
                }
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name.Contains("Tesla Coil")) 
        {
            PickUp = false;
        }
    }
}
