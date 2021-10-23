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
    private Vector3 transformInstantiate;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                Instantiate(pointer);
                pointer.transform.position = raycastHit.point + raycastHit.normal * 0.01f;
            }
        }

        
        if (Input.GetMouseButtonUp(0))
        {
            Fire();
        }

    }

    private void Fire()
    {
        mousePosition = Input.mousePosition; 
        ray = Camera.main.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f , Color.red, 10f);
        Instantiate(bullet ,transform.position,Quaternion.FromToRotation(transform.position,pointer.position));
    }
}
