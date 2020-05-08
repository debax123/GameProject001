using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUps : MonoBehaviour
{
    private bool isOn;
    public GameObject tutorialGUI1;
    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        tutorialGUI1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn == false)
        {
            tutorialGUI1.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isOn = true;
            tutorialGUI1.SetActive(true);
            StartCoroutine(IsOnTimer());
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isOn = false;
                tutorialGUI1.SetActive(false);
        }
    }
    private IEnumerator IsOnTimer()
    {
        if (isOn)
        {
            yield return new WaitForSeconds(2);
            tutorialGUI1.SetActive(false);
            isOn = false;
            StopAllCoroutines();
        }
    }
}
