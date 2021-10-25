using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackRay : MonoBehaviour
{
    [SerializeField] private Transform _pointer = null;
    [SerializeField] private Bullet bulletPrefab = null;
    [SerializeField] private float _force = 0f;
    
    private Ray _ray; // почитать
    private Vector3 _relativePos = Vector3.zero;
    private RaycastHit _raycastHit; // почитать
    private Vector3 _mousePosition = Vector3.zero;

    
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
        Bullet bullet = Instantiate(bulletPrefab, _ray.origin, Quaternion.LookRotation(_relativePos));
        bullet.AddForce((_relativePos).normalized * _force);
    }

    class Bullet : MonoBehaviour // вынести в другой файл
    {
        [SerializeField] private Rigidbody rigidbody;

        public void AddForce(Vector3 force)
        {
            rigidbody.AddForce(force);
        }
    }
}
