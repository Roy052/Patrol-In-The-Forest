using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : MonoBehaviour
{
    GameObject mouse;
    public DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Mouse");
    }

    private void OnMouseEnter()
    {
        mouse.GetComponent<MousePosition>().ToInvestigate();
        Debug.Log("Mouse In");
    }
    private void OnMouseDown()
    {
        dialogueTrigger.TriggerDialogue();
    }

    private void OnMouseExit()
    {
        mouse.GetComponent<MousePosition>().ToHand();
    }
}
