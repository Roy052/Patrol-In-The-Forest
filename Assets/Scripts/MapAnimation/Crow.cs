using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    bool timeToFly = false;
    float moveSpeed = 10f;
    AudioSource crowSound;
    bool onetime = false;

    private void Start()
    {
        movement = new Vector2(0, 1);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        crowSound = this.gameObject.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if(timeToFly == true)
        {
           rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            if (onetime == false)
            {
                crowSound.Play();
                onetime = true;
            }
            
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        if (this.transform.position.y >= 20)
        {
            timeToFly = false;
            crowSound.Stop();
        }
            
    }

    public void triggerON()
    {
        timeToFly = true;
        this.gameObject.SetActive(true);
    }
}
