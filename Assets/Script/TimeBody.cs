using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;
    private List<PointInTime> _pointInTimes = null;
    private Rigidbody _rb = null;

    
    private void Start()
    {
        _pointInTimes = new List<PointInTime>();
        _rb = GetComponent<Rigidbody>();
    }
    
    
    private void Update()
    {
        if (isRewinding)
        {
            return;
        }

        if(!Mathf.Approximately(_rb.velocity.y, 0) && !isRewinding) 
        {
            Record();
        }
    }

    
    private async void Rewinding()
    {
        while (_pointInTimes.Count > 0)
        {
            PointInTime pointInTime = _pointInTimes[0];
            transform.position = pointInTime.positon;
            transform.rotation = pointInTime.rotation;
            _pointInTimes.RemoveAt(0);
            await Task.Yield();
        }
        StopRewind();
    }

    
    private void Record()
    {
        _pointInTimes.Insert(0,new PointInTime(transform.position,transform.rotation));
    }

    
    private void StartRewind()
    {
        _rb.isKinematic = true;
        isRewinding = true;
    }

    
    private void StopRewind()
    {
        _rb.isKinematic = false;
        isRewinding = false;
    }
    
    
    public void OnButtomDown()
    {
        if (_pointInTimes.Count > 0 && !isRewinding)
        {
            Debug.Log("True REWIND");
            StartRewind();
            Rewinding();
        }
    }
}
