using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorstop : MonoBehaviour
{
    private Rigidbody Pivot;
    // Start is called before the first frame update
    void Start()
    {
        Pivot = transform.root.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            Pivot.angularVelocity = Vector3.zero;
        }
    }
}
