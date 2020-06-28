using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerBlue : MonoBehaviour
{
    private GameObject orangePortal;

    public bool flag = true;

    float exitAngle;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        orangePortal = GameObject.FindGameObjectWithTag("orangePortal");
        //exitAngle = transform.rotation.eulerAngles.z + 90;  //orangePortal.transform.rotation.eulerAngles.z + transform.rotation.eulerAngles.z;
        //print(exitAngle);
        //exitAngle = (Quaternion.Euler(0, 0, exitAngle)).z;
        //exitAngle = exitAngle * Mathf.Deg2Rad;
        //print(exitAngle);
        //print();


        //GameObject.Find("Companion Cube").GetComponent<Rigidbody2D>().velocity = new Vector2( 3, 10 );
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( flag ) 
        {
            orangePortal.GetComponent<TeleportationHandlerOrange>().flag = false;

            //collision.gameObject.transform.position = orangePortal.transform.position;

            vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            /*
                        float x1 = vel.x;
                        float y1 = vel.y;
                        float x2 = (float)((Mathf.Cos(exitAngle) * x1) - (Mathf.Sin(exitAngle) * y1));
                        float y2 = (float)((Mathf.Sin(exitAngle) * x1) + (Mathf.Cos(exitAngle) * y1));

                        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x2, y2);*/

            /*if ( exitAngle == -90)
            {
                exitAngle -= 90;
            }*/
            //Quaternion uhh = Quaternion.Euler(0, 0, exitAngle);

            //Vector2 newDir = Quaternion.AngleAxis(exitAngle, Vector3.forward) * vel;
            exitAngle = transform.rotation.eulerAngles.z + 90;

            Vector2 newDir = Quaternion.Euler(0, 0, exitAngle) * vel;

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newDir;

            print(vel);
            print(newDir);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = true;
    }

}
