using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Button Next;
    string tempSentence;
    bool displayRunning;
    bool skipSign;

    private void Start()
    {
        sentences = new Queue<string>();
        nameText.text = "";
        dialogueText.text = "";
        Next.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start " + dialogue.dialogue_name);
        if(dialogue.dialogue_name != "")
        {
            nameText.text = dialogue.dialogue_name + " : ";
        }
        
        Next.gameObject.SetActive(true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        skipSign = false;
        if (displayRunning)
        {
            Skip();
        }
        else
        {
            if (sentences.Count <= 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            tempSentence = sentence;
            StartCoroutine(displayPro(sentence));
            Debug.Log(sentence);
        }
    }

    IEnumerator displayPro(string sentence)
    {
        displayRunning = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            if (skipSign == true) break;
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.08f);
            
        }
        displayRunning = false;

    }

    public void Skip()
    {
        skipSign = true;
        dialogueText.text = tempSentence;
    }
    void EndDialogue()
    {
        nameText.text = "";
        dialogueText.text = "";
        Next.gameObject.SetActive(false);
        Debug.Log("End");
    }
}
