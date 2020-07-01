using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    Camera cam;

    Vector3 point;
    public static Vector3 mousePos;

    float angle;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition);

        mousePos = point;

        point -= transform.position;

        point = point.normalized;


        angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        
        
    }
}
