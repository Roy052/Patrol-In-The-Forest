using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialogue : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    bool onetime = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (onetime == false)
        {
            if (collision.gameObject.name == "Player")
            {
                onetime = true;
                dialogueTrigger.TriggerDialogue();
            }
        }
    }
}
