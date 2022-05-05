using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
    public string jobName;
    public bool isComplete = false, isConditionComplete = false;
    public bool[] condition;
    int conditionNum;

    private void Start()
    {
        conditionNum = condition.Length;
    }

    private void Update()
    {
        if (isComplete == false)
        {
            for (int i = 0; i < conditionNum; i++)
            {
                if (condition[i] == true)
                {
                    isConditionComplete = true;
                }
                else
                {
                    isConditionComplete = false;
                    break;
                }
            }
            if (isConditionComplete == true) Complete();
        }
    }

    public void ConditionComplete(int num)
    {
        condition[num] = true;
    }

    public void Complete()
    {
        Debug.Log(jobName + " is Completed");
        isComplete = true;
    }
}
