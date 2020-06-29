using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerOrange : MonoBehaviour
{
    private GameObject bluePortal;

    public bool flag = true;

    float exitAngle;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        bluePortal = GameObject.FindGameObjectWithTag("bluePortal");
        exitAngle = bluePortal.transform.rotation.eulerAngles.z;
        //exitAngle = bluePortal.transform.rotation.eulerAngles.z + transform.rotation.eulerAngles.z;
        //exitAngle = exitAngle * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( flag )
        {
            print("orange");
            bluePortal.GetComponent<TeleportationHandlerBlue>().flag = false;
            collision.gameObject.transform.position = bluePortal.transform.position;

            //vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            vel = new Vector2(-5, -10);

            /*float x1 = vel.x;
            float y1 = vel.y;
            float x2 = (float)((Mathf.Cos(exitAngle) * x1) - (Mathf.Sin(exitAngle) * y1));
            float y2 = (float)((Mathf.Sin(exitAngle) * x1) + (Mathf.Cos(exitAngle) * y1));

            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x2, y2);*/

            //print(exitAngle);
            Vector2 newDir;

            switch (exitAngle)
            {
                case 360:
                    newDir = -vel;
                    break;
                case 90:
                    newDir = -vel;
                    break;
                default:
                    newDir = Quaternion.Euler(0, 0, exitAngle) * vel;
                    break;
            }




            collision.gameObject.GetComponent<Rigidbody2D>().velocity = newDir;

            //print(vel);
            //print(newDir);


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = true;
    }

}
