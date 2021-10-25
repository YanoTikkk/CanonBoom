using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer = null;
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float force = 0f;

    private Vector3 mousePosition = Vector3.zero;
    private Vector3 relativePos = Vector3.zero;
    private RaycastHit raycastHit;
    private Ray ray;


    private void Update()
    {
        mousePosition = Input.mousePosition;
        ray = Camera.main.ScreenPointToRay(mousePosition);
        
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                pointer.position = raycastHit.point;
            }
        }
        
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out raycastHit))
            {
                Fire();
                pointer.position = mousePosition;
            }
        }
    }
    
    
    private void Fire()
    {
        relativePos = raycastHit.point - transform.position;
        Bullet bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.LookRotation(relativePos));
        bullet.AddForce((relativePos).normalized * force);
    }
}
