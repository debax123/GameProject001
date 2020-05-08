using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothspeed = 0.125f;

    public bool useOffsetValues;

    public Vector3 offset;

    public float rotateSpeed;

   // void Start()
    //{
    //    if (!useOffsetValues)
      //  {
      //      offset = target.position - transform.position;
       // }
    //}
    private void FixedUpdate()
    {
        Vector3 forward = target.forward;
        Vector3 right = target.right;

        forward.Normalize();
        right.Normalize();



        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedPosition;

        //float horizontal = Input.GetAxis("Horizontal") * rotateSpeed;
        //target.Rotate(0, horizontal, 0);

        //float desiredYAngle = target.eulerAngles.y;

        //Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);
        //transform.position = target.position - (rotation * offset);
        transform.rotation = target.rotation;
    }
}
