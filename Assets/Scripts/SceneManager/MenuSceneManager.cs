using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    public Animator animator;
    public GameObject fade;
    public void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        animator.SetBool("FadeOut", false);
        fade = GameObject.Find("Fade");
        fade.SetActive(false);
    }
    public void Next()
    {
        fade.SetActive(true);
        animator.SetBool("FadeOut", true);
        StartCoroutine(FadeComplete());
    }

    public void Option()
    {
        Debug.Log("Option");
    }

    public void Key()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator FadeComplete()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
