using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{
    public static bool event1;
    // Start is called before the first frame update
    void Start()
    {
        event1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F4))
        {
            ScoreScript.fishCount += 8;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(ScoreScript.fishCount >= 15)
            {
                //ScoreScript.fishCount = 15;
                event1 = true;
            }
        }
    }
}
