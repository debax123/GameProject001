﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform pivot;

    public Transform target;

    public Vector3 offset;

    public float rotateSpeed;

    public float maxViewAngle;
    public float minViewAngle;

    public bool invertY;

    // Start is called before the first frame update
    void Start()
    {
        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (DialogueSystem.dialogueActive == false)
        {
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;

            target.Rotate(0, horizontal, 0);



            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

            if(invertY)
            {
                pivot.Rotate(vertical, 0, 0);
            } else
            {
                pivot.Rotate(-vertical, 0, 0);
            }

            //Limit up/down camera rotation

            if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
            {
                pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);

            }


            if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
            {
                pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
            }


            //Move the camera based on the current rotation of the target & the original offset
                float desiredYAngle = target.eulerAngles.y;
            float desiredXAngle = pivot.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngle, 0);
            transform.position = target.position - (rotation * offset);

            if (transform.position.y < target.position.y + minViewAngle)
            {
                transform.position = new Vector3(transform.position.x, target.position.y +.5f, transform.position.z);
            }

            //transform.position = target.position - offset;
            transform.LookAt(target);

            /*if (!Move2.controller.isGrounded)
            {
           
            }*/
        }
    }
}
