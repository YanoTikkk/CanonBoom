using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private GameObject gameObjectBullet;
    [SerializeField] private float force;
    private Ray ray;
    private Vector3 relativePos;
    private RaycastHit raycastHit;
    private Vector3 mousePosition;
    
    private void Update()
    {
        mousePosition = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePosition);
        
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                pointer.position = raycastHit.point;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            pointer.position = mousePosition;
        }
    }


    private void Fire()
    {
        relativePos = raycastHit.point - transform.position;
        var bullets = Instantiate(gameObjectBullet, ray.origin, Quaternion.LookRotation(relativePos));
        var rb = bullets.GetComponent<Rigidbody>();
        rb.AddForce((relativePos).normalized * force);
    }
}
