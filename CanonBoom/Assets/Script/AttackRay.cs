using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform pointer;
    private Ray rayAttack;
    private RaycastHit raycastHit;
    public Vector3 mousePosition;
    [SerializeField] private Vector3 bulletPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Camera cameraMain;

    private void Update()
    {
        mousePosition = Input.mousePosition;
        Ray ray = cameraMain.ScreenPointToRay(mousePosition);
        Debug.DrawRay(transform.position, transform.forward *100f,Color.red);
        
        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(bullet , bulletPosition , new Quaternion(0,0,0,0));
        }
        
        if (Physics.Raycast(rayAttack,out raycastHit))
        {
            pointer.transform.position = raycastHit.point;
        }
    }
    
}
