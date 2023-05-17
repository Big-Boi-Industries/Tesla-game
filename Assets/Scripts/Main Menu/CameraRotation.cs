using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] float movementTime;
    [SerializeField] Vector3 targetLookingPosition;
    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetLookingPosition);
        transform.Translate(Vector3.right * movementTime);
    }
}
