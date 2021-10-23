using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float stronge;
    [SerializeField] private float lifeBullet;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.forward , ForceMode.Impulse);
        
        lifeBullet -= Time.deltaTime;
        if (lifeBullet <= 0)
        {
            Destroy(gameObject);
        }
    }
}