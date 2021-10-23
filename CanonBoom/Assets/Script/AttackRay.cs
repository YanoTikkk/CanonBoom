using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cameraMain;
    private Ray ray;
    private RaycastHit raycastHit;
    private Vector3 mousePosition;
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            setAim();
        }

        
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }

    }

    private void setAim()
    {
        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider == null) return;

            Instantiate(pointer,raycastHit.point,Quaternion.identity);
        }
    }
    
    private void Fire()
    {
        mousePosition = Input.mousePosition; 
        ray = Camera.main.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f , Color.red, 10f);
        Instantiate(bullet ,transform.position,Quaternion.FromToRotation(transform.position,raycastHit.point));
        Debug.Log(bullet.transform.position);
    }
}
