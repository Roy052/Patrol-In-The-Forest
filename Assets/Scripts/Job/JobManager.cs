using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobManager : MonoBehaviour
{
    public Job[] jobList;
        int jobNum;
    bool isComplete;
    MainSceneManager msm;
    public Text[] jobTextList;
    public GameObject[] jobCheckList;

    private void Start()
    {
        jobNum = jobList.Length;
        isComplete = false;
        msm = FindObjectOfType<MainSceneManager>();
        for(int i = 0; i < 4; i++)
        {
            if(i < jobNum)
            {
                jobTextList[i].text = jobList[i].jobName;
                jobCheckList[i].gameObject.SetActive(false);
            }
            else
            {
                jobTextList[i].text = "";
                jobCheckList[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        for(int i = 0; i < jobNum; i++)
        {
            if (jobList[i].isComplete == true)
            {
                jobCheckList[i].gameObject.SetActive(true);
                isComplete = true;
            }
            else
            {
                isComplete = false;
                break;
            }
        }

        if (isComplete == true) 
            StartCoroutine(msm.Next());
    }

    public void JobWork(int job, int cond)
    {
        jobList[job].ConditionComplete(cond);
    }
}
