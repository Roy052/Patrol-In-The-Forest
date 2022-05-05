using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operate : MonoBehaviour
{
    GameObject mouse;
    public DialogueTrigger dialogueTrigger;
    public Animator animator;
    public GameObject ConnectedWall;
    MainSceneManager msm;
    JobManager jm;
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Mouse");
        if(animator != null)
            animator.SetBool("ON", false);
        msm = GameObject.Find("MainSceneManager").GetComponent<MainSceneManager>();
        jm = GameObject.Find("JobManager").GetComponent<JobManager>();
        if (this.gameObject.tag == "Fence") ConnectedWall.SetActive(false);
    }

    private void OnMouseEnter()
    {
        mouse.GetComponent<MousePosition>().ToOperate();
        Debug.Log("Mouse In");
    }

    private void OnMouseExit()
    {
        mouse.GetComponent<MousePosition>().ToHand();
    }

    private void OnMouseDown()
    {
        dialogueTrigger.TriggerDialogue();
        if(animator != null)
            animator.SetBool("ON", true);
        if(this.gameObject.tag == "SealStone")
        {
            StartCoroutine(SealSteneOperate());
        }
        else if (this.gameObject.tag == "Fence")
        {
            StartCoroutine(FenceOperate());
        }
    }

    IEnumerator SealSteneOperate()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectedWall.GetComponent<Animator>().SetBool("ON", true);
        yield return new WaitForSeconds(1.5f);
        ConnectedWall.SetActive(false);
    }

    IEnumerator FenceOperate()
    {
        yield return new WaitForSeconds(0.5f);
        ConnectedWall.SetActive(true);
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }

    IEnumerator BookshelfOperate()
    {
        yield return new WaitForSeconds(1.0f);
        msm.Bookshelf();
    }

    IEnumerator DeskOperate()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectedWall.GetComponent<Animator>().SetBool("ON", true);
        yield return new WaitForSeconds(1.5f);
        ConnectedWall.SetActive(false);
    }

    IEnumerator InvestigateTableOperate()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectedWall.GetComponent<Animator>().SetBool("ON", true);
        yield return new WaitForSeconds(1.5f);
        ConnectedWall.SetActive(false);
    }

    IEnumerator SafeOperate()
    {
        yield return new WaitForSeconds(1.0f);
        ConnectedWall.GetComponent<Animator>().SetBool("ON", true);
        yield return new WaitForSeconds(1.5f);
        ConnectedWall.SetActive(false);
    }
}
