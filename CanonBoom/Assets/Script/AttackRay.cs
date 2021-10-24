using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private GameObject gameObjectBullet;
    [SerializeField] private Camera cameraMain;
    [SerializeField] private float force;
    private Ray ray;
    private Ray newRay;
    private Vector3 relativePos;
    private RaycastHit raycastHit;
    private Vector3 mousePosition;
    
    private void Update()
    {
        mousePosition = Input.mousePosition; 
        ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            setAim();
        }

        
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
            Destroy(GameObject.Find("Aim(Clone)"),0.1f);
        }

    }

    private void setAim()
    {
        if (Physics.Raycast(ray, out raycastHit))
        {
            var point = Instantiate(pointer,raycastHit.point,Quaternion.identity);
            
            if (Input.GetMouseButton(0))
            {
                point.position = raycastHit.point;
            }
            
        }
    }
    
    private void Fire()
    {
        relativePos = raycastHit.point - transform.position;
        var bullets = Instantiate(gameObjectBullet ,ray.origin,Quaternion.LookRotation(relativePos));
        var rb = bullets.GetComponent<Rigidbody>();
        rb.AddForce((relativePos).normalized * force);
    }
}
