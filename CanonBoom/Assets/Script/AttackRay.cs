using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cameraMain;
    private Ray rayAttack;
    private RaycastHit raycastHit;
    private Vector3 mousePosition;
    private Vector3 transformInstantiate;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10f , Color.red, 10f);

            if (Input.GetMouseButtonUp(0))
             {
                Instantiate(bullet , transformInstantiate , new Quaternion(0,0,0,0));
             }
        }
        if (Physics.Raycast(rayAttack, out raycastHit))
        {
            Debug.Log("good");
            pointer.position = raycastHit.point;
        }
    }
}
