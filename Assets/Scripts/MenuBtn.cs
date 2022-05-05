using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    MenuSceneManager msm;

    private void Start()
    {
        msm = GameObject.Find("MenuSceneManager").GetComponent<MenuSceneManager>();

    }

    private void OnMouseDown()
    {
        if (this.name == "Start") msm.Next();
        else msm.Exit();
    }
}
