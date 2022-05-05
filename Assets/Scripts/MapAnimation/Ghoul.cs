using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    bool timeToGrowl = false;
    AudioSource ghoulSound;
    bool onetime = false;

    private void Start()
    {
        ghoulSound = this.gameObject.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (timeToGrowl == true)
        {
            if (onetime == false)
            {
                ghoulSound.Play();
                onetime = true;
            }

        }
        if (this.transform.position.y >= 20)
        {
            timeToGrowl = false;
            ghoulSound.Stop();
        }

    }

    public void triggerON()
    {
        timeToGrowl = true;
        this.gameObject.SetActive(true);
    }
}
