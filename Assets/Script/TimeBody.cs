using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    private bool isRewinding = false;
    private List<PointInTime> pointInTimes = null;
    private Rigidbody rb = null;

    
    private void Start()
    {
        pointInTimes = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }
    
    
    private void Update()
    {
        if (isRewinding)
        {
            return;
        }

        if(!Mathf.Approximately(rb.velocity.y, 0) && !isRewinding) 
        {
            Record();
        }
    }

    
    private async void Rewinding()
    {
        while (pointInTimes.Count > 0)
        {
            PointInTime pointInTime = pointInTimes[0];
            transform.position = pointInTime.positon;
            transform.rotation = pointInTime.rotation;
            pointInTimes.RemoveAt(0);
            await Task.Yield();
        }
        StopRewind();
    }

    
    private void Record()
    {
        pointInTimes.Insert(0,new PointInTime(transform.position,transform.rotation));
    }

    
    private void StartRewind()
    {
        rb.isKinematic = true;
        isRewinding = true;
    }

    
    private void StopRewind()
    {
        rb.isKinematic = false;
        isRewinding = false;
    }
    
    
    public void OnButtomDown()
    {
        if (pointInTimes.Count > 0 && !isRewinding)
        {
            Debug.Log("True REWIND");
            StartRewind();
            Rewinding();
        }
    }
}
