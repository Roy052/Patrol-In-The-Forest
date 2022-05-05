using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    public Animator animator;
    public GameObject arm;
    private void Start()
    {
        arm.SetActive(false);   
    }
    public void triggerON()
    {
        animator.SetBool("ON", true);
        if(this.gameObject.name == "BushArm" || this.gameObject.name == "BushArm1")
        {
            arm.SetActive(true);
        }
    }
}
