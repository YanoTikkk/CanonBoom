using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;

    private List<PointInTime> pointInTimes;
    private Rigidbody rb;

    private void Start()
    {
        pointInTimes = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (pointInTimes.Count > 0)
            {
                startRewind();
            }
            else
            {
                startRewind();
            }
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            rewinding();
        }
        else
        {
            record();
        }
    }

    private void rewinding()
    {
        if (pointInTimes.Count > 0)
        {
            PointInTime pointInTime = pointInTimes[0];
            transform.position = pointInTime.positon;
            transform.rotation = pointInTime.rotation;
            pointInTimes.RemoveAt(0);
        }
        else
        {
           stopRewind(); 
        }
    }

    private void record()
    {
        pointInTimes.Insert(0,new PointInTime(transform.position,transform.rotation));
    }

    public void startRewind()
    {
        rb.isKinematic = true;
        isRewinding = true;
    }

    public void stopRewind()
    {
        rb.isKinematic = false;
        isRewinding = false;
    }
}
