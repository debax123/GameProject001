using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    [System.Serializable]
public class NPC : MonoBehaviour
{
    public Image image;
    public Transform ChatBackground;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;

    [TextArea(5, 10)]
    public string[] Sentences;


    // Start is called before the first frame update
    void Start()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //ChatBackground.position = Camera.main.WorldToScreenPoint(NPCCharacter.position + Vector3.up * 7f);
        Vector3 pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
        //pos.y += 100;
        ChatBackground.position = image.transform.position;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
            if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
            {
                this.gameObject.GetComponent<NPC>().enabled = true;
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = Sentences;
                FindObjectOfType<DialogueSystem>().NPCName();
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;
    }
}
