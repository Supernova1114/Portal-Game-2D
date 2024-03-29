﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerBlue : MonoBehaviour
{
    private GameObject orangePortal;

    public bool flag = true;

    float exitAngle;
    Vector2 vel;
    Vector2 newVel;


    void Awake()
    {
        orangePortal = GameObject.FindGameObjectWithTag("orangePortal");

        exitAngle = Mathf.Deg2Rad * (orangePortal.transform.rotation.eulerAngles.z + 90);

        newVel = new Vector2(Mathf.Cos(exitAngle), Mathf.Sin(exitAngle));

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (orangePortal.activeInHierarchy)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (flag)
                {
                    orangePortal.GetComponent<TeleportationHandlerOrange>().flag = false;

                    //orangePortal.transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;
                    //orangePortal.transform.parent.gameObject.GetComponent<Rigidbody2D>().simulated = false;

                    collision.gameObject.transform.position = orangePortal.transform.position;

                    vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

                    collision.gameObject.GetComponent<Rigidbody2D>().velocity = newVel * vel.magnitude;

                    //print("blue: " + vel.magnitude);
                    //print( newVel.magnitude );
                    //print( (newVel * vel.magnitude).magnitude );
                }

            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            flag = true;
            //transform.parent.gameObject.GetComponent<Rigidbody2D>().simulated = true;
            //transform.parent.gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

}
