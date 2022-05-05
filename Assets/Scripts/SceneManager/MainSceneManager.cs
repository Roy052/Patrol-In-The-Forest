using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public Animator animator;
    public GameObject fade;
    public bool body, bookshelf, desk, investigateTable, safe;
    [SerializeField] private Camera mainCamera;
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        fade = GameObject.Find("Fade");
        StartCoroutine(AfterFade());
    }

    private void Update()
    {
        mainCamera = Camera.main;
        if(body == true)
        {
            mainCamera.transform.Translate(new Vector3(0, 0, 0));
        }
    }

    public IEnumerator Next()
    {
        yield return new WaitForSeconds(1f);
        fade.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        if(SceneManager.GetActiveScene().buildIndex >= 7)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
    }

    IEnumerator AfterFade()
    {
        yield return new WaitForSeconds(1f);
        fade.SetActive(false);
    }

    public void Body()
    {
        body = true;
    }

    public void OutBody()
    {
        body = false;
    }

    public void Bookshelf()
    {
        bookshelf = true;
    }
    public void OutBookshelf()
    {
        bookshelf = false;
    }

    public void Desk()
    {
        SceneManager.LoadScene("S#7_Desk");
    }
    
    public void InvestigateTable()
    {
        SceneManager.LoadScene("S#8_InvestigateTable");
    }

    public void Safe()
    {
        SceneManager.LoadScene("S#9_Safe");
    }
}
