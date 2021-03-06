﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float DestroyTimer;
    public LayerMask DestroyableObjects;
    Vector2 MousePos;
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        MousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Collider2D Destroyed = Physics2D.OverlapCircle(MousePos, 0.5f, DestroyableObjects);
        Debug.Log(Physics2D.OverlapCircle(MousePos, 0.5f, DestroyableObjects));
        if(Destroyed != null)
        {
            Destroy(Destroyed.gameObject);
        }
        Destroy(gameObject, DestroyTimer);
    }

    
}
