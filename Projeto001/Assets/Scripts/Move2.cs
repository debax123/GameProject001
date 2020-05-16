using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float pushPower = 1.0f;
    public float moveSpeed;
    //public Rigidbody rb;
    public float jumpForce;
    public static CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
            //rb = GetComponent<Rigidbody>();
            controller = GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpped, rb.velocity.y, Input.GetAxis("Vertical") * moveSpped);
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpped, moveDirection.y, Input.GetAxis("Vertical") * moveSpped);
        /*if (controller.enabled == true)
        {*/
            if (DialogueSystem.dialogueActive == false)
            {
                float yStore = moveDirection.y;
                moveDirection = (transform.forward * Input.GetAxis("Vertical") * moveSpeed) + (transform.right * Input.GetAxis("Horizontal") * moveSpeed);
                moveDirection = moveDirection.normalized * moveSpeed;
                moveDirection.y = yStore;


                    moveDirection.y = 0f;

                if(controller.isGrounded)
                {
                    if(Input.GetButtonDown("Jump"))
                    {
                        moveDirection.y = jumpForce;
                    } else
                    {
                        gravityScale = 0.5f;
                        moveDirection.y -= gravityScale * Time.deltaTime;
                    }
                    //gravityScale = 1;
                }


                moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                controller.Move(moveDirection * Time.deltaTime);
            }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish")/* && (Input.GetKeyDown(KeyCode.C)*/)
        {
            other.gameObject.SetActive(false);
            ScoreScript.fishCount++;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        moveDirection.y += 1;
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * pushPower;

    }
}
