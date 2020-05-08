using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor2 : MonoBehaviour
{
    public GameObject door;
    private void OnTriggerEnter(Collider other)
    {
        if(ScoreScript.fishCount >= 15 && Change.event1 == true)
        {
            door.SetActive(false);
        }
    }
}
