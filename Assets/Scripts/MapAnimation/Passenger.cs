using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movement;
    bool timeToMove = false;
    float moveSpeed = 5f;
    AudioSource passengerSound;
    bool onetime = false;
    bool onetime2 = false;

    private void Start()
    {
        movement = new Vector2(1, 0);
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        passengerSound = this.gameObject.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (timeToMove == true)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            if (onetime == false)
            {
                passengerSound.Play();
                onetime = true;
            }

        }
        
        
        if (this.transform.position.x >= -220)
        {
            timeToMove = false;
            passengerSound.Stop();
            if (this.name == "Passenger_Red")
            {
                Vector3 tempLocalscale;
                tempLocalscale = this.transform.localScale;
                if(onetime2 == false)
                {
                    tempLocalscale.x *= -1;
                    transform.localScale = tempLocalscale;
                    onetime2 = true;
                }
                
                
            }
            else
            this.gameObject.SetActive(false);
        }

    }

    public void triggerON()
    {
        timeToMove = true;
    }
}
