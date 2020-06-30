using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerOrange : MonoBehaviour
{
    private GameObject bluePortal;

    public bool flag = true;

    float exitAngle;
    Vector2 vel;
    Vector2 newVel;


    void Start()
    {
        bluePortal = GameObject.FindGameObjectWithTag("bluePortal");

        exitAngle = Mathf.Deg2Rad * (bluePortal.transform.rotation.eulerAngles.z + 90);

        newVel = new Vector2(Mathf.Cos(exitAngle), Mathf.Sin(exitAngle));

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (flag)
        {
            bluePortal.GetComponent<TeleportationHandlerBlue>().flag = false;

            collision.gameObject.transform.position = bluePortal.transform.position;

            vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVel * vel.magnitude;

            //print("orange: " + vel.magnitude);
            //print(newVel.magnitude);
            //print((newVel * vel.magnitude).magnitude);

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = true;
    }

}
