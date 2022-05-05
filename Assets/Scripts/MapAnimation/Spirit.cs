using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit : MonoBehaviour
{
    public GameObject player;
    bool timeToOpen = false;
    AudioSource galaxySound;
    bool onetime = false;
    JobManager jm;

    private void Start()
    {
        galaxySound = this.gameObject.GetComponent<AudioSource>();
        jm = FindObjectOfType<JobManager>();
    }
    void FixedUpdate()
    {
        if (timeToOpen == true)
        {
            if (onetime == false)
            {
                galaxySound.Play();
                onetime = true;
            }
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.SetActive(false);
            jm.JobWork(0, 0);
        }
        
    }
    public void triggerON()
    {
        timeToOpen = true;
        this.gameObject.SetActive(true);
    }
}
