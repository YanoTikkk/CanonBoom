using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float stronge;
    [SerializeField] private float lifeBullet;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.TransformDirection(Input.mousePosition * 1);

        lifeBullet -= Time.deltaTime;
        if (lifeBullet <= 0)
        {
            Destroy(gameObject);
        }
    }
}