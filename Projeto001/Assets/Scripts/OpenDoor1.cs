using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour
{
    public Animator door1;
    public bool RightNumberOfFish;
    public GameObject door;

    private void Start()
    {
        RightNumberOfFish = false;
    }
    public void Update()
    {
        if(RightNumberOfFish)
        {
            door1.SetBool("RightNumberOfFish", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(ScoreScript.fishCount >= 8)
        {
            RightNumberOfFish = true;
        }
    }
}
