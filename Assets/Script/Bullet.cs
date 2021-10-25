using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeBullet = 0f;
    [SerializeField] private Rigidbody rigidbody = null;

    
    private void Update()
    {
        lifeBullet -= Time.deltaTime;
        
        if (lifeBullet <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
    public void AddForce(Vector3 force)
    {
        rigidbody.AddForce(force);
    }
}