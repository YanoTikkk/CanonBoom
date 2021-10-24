using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
    public bool isRewinding = false;

    private List<Vector3> positions;
    private Rigidbody rb;

    private void Start()
    {
        positions = new List<Vector3>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startRewind();
        }

        if (Input.GetMouseButtonUp(1))
        {
            stopRewind();
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
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
           stopRewind(); 
        }
    }

    private void record()
    {
        positions.Insert(0,transform.position);
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
