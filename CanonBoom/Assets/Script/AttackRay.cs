using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    private Ray rayAttack;
    private RaycastHit raycastHit;
    [SerializeField] private Vector3 bulletPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cameraMain;

    private void Update()
    {
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward *100f,Color.red);
        
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bullet , bulletPosition , new Quaternion(0,0,0,0));
        }
        
        if (Physics.Raycast(rayAttack,out raycastHit))
        {
            pointer.position = raycastHit.point;
        }
    }
    
}
