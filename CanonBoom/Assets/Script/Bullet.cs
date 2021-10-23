using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        rb.AddForce(Input.mousePosition * stronge);
        
        lifeBullet -= Time.deltaTime;
        if (lifeBullet <= 0)
        {
            Destroy(gameObject);
        }
    }
}