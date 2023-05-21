using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorstop : MonoBehaviour
{
    public static bool CanMove = true;
    public static bool BackStop = false;
    public static bool FrontStop = false;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            if (gameObject.name.Contains("Back") & !FrontStop) { BackStop = true; }
            if (gameObject.name.Contains("Front") & !BackStop) { FrontStop = true; }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            CanMove = false;
            Pivot.angularVelocity = Vector3.zero;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            CanMove = true;
            BackStop = false;
            FrontStop = false;
        }
    }
}
