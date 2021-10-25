using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private GameObject _gameObjectBullet;
    [SerializeField] private float _force;
    private Ray _ray;
    private Vector3 _relativePos;
    private RaycastHit _raycastHit;
    private Vector3 _mousePosition;
    
    private void Update()
    {
        _mousePosition = Input.mousePosition;
        _ray = Camera.main.ScreenPointToRay(_mousePosition);
        
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(_ray, out _raycastHit))
            {
                _pointer.position = _raycastHit.point;
            }
        }
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(_ray, out _raycastHit))
            {
                Fire();
                _pointer.position = _mousePosition;
            }
        }
    }


    private void Fire()
    {
        _relativePos = _raycastHit.point - transform.position;
        var bullets = Instantiate(_gameObjectBullet, _ray.origin, Quaternion.LookRotation(_relativePos));
        var rb = bullets.GetComponent<Rigidbody>();
        rb.AddForce((_relativePos).normalized * _force);
    }
}
