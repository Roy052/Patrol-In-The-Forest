using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOccur : MonoBehaviour
{
    bool onetime = false;
    Crow crow;
    Spirit spirit;

    private void Start()
    {
        crow = FindObjectOfType<Crow>();
        spirit = FindObjectOfType<Spirit>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (onetime == false)
        {
            if (collision.gameObject.name == "Player")
            {
                onetime = true;
                if (this.name == "CrowEnter")
                {
                    crow.triggerON();
                }
                else if (this.name == "BushEnter")
                {
                    Bush bush = FindObjectOfType<Bush>();
                    bush.triggerON();
                }
                else if(this.name == "PassengerEnter")
                {
                    Passenger passenger = FindObjectOfType<Passenger>();
                    passenger.triggerON();
                }
                else if(this.name == "GhoulEnter")
                {
                    Ghoul ghoul = FindObjectOfType<Ghoul>();
                    ghoul.triggerON();
                }
                else if(this.name == "EndEnter")
                {
                    JobManager jm = FindObjectOfType<JobManager>();
                    jm.JobWork(0, 0);
                }
                else if(this.name == "SpiritEnter")
                {
                    spirit.triggerON();
                }
            }

            
        }
    }
}
