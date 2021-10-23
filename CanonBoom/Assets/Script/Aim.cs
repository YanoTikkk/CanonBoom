using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Hello");
    }

    void Update()
    {
        Destroy(gameObject,15f);
    }
}
