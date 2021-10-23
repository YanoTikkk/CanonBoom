using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    private Ray rayAttack;
    private Vector3 mousePosition;
    private RaycastHit raycastHit; 
    [SerializeField] private GameObject bullet;


    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rayAttack = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);
        }

        if (Physics.Raycast(rayAttack,out raycastHit))
        {
            pointer.position = raycastHit.point;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bullet);
        }
    }
}
