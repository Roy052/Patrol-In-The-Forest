using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    
    [Range(1,10)]
    public float smoothFactor;
    float x = 10.29f, y = 2.85f;

    void Start()
    {
        offset.z = -10;
        offset.x = -x;
        offset.y = y;
    }

    void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        if (target.GetComponent<PlayerMovement>().facingLeft == true)
        {
            offset.x = -x;
            smoothFactor = 5;
        }
        else
        {
            offset.x = x;
            smoothFactor = 5;
        }
        Vector3 targetPos = target.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPos;
        smoothFactor = 10;
    }
}
