using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int fishCount;
    public Text fishCountText;

    // Start is called before the first frame update
    void Start()
    {
        fishCountText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Change.event1 == false)
        {
            fishCountText.text = "Fish Collected" + fishCount;
        }
        if (Change.event1 == true)
        {
            fishCountText.text = "Souls" + fishCount;
        }
    }
}
