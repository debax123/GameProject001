using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontGoUp : MonoBehaviour
{
    public float gravity2;
    Transform position;
    //Rigidbody rb;
    float lastHeight;
    // Start is called before the first frame update
    void Start()
    {
        position.GetComponent<Transform>();
        //rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(new Vector3(0, gravity2, 0), ForceMode.Force);
        lastHeight = position.position.y;
        if (position.position.y > lastHeight)
        {
            position.position = new Vector3(position.position.x, position.position.y, position.position.z);
        }
    }

    
}
