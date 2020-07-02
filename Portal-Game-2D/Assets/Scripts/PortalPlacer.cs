using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlacer : MonoBehaviour
{

    public GameObject bluePortal;
    public GameObject orangePortal;

    //public Rigidbody2D body;

    //RaycastHit2D cast;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetMouseButtonDown(0))
        {
            //print("heya");
            PlaceBlue();
        }

        if (Input.GetMouseButtonDown(1))
        {
            PlaceOrange();
        }

    }

    void PlaceBlue()
    {
        if ( GameObject.FindWithTag("bluePortal") != null)
        {

            RaycastHit2D cast;
            //print("placed");
            mousePos = (Vector2)Pointer.mousePos;

            //body.velocity = (mousePos - (Vector2)transform.position).normalized * 5;

            cast = Physics2D.Raycast((Vector2)transform.position, (mousePos - (Vector2)transform.position).normalized);


            if (cast.collider != null)
            {
                bluePortal.transform.parent = null;

                bluePortal.transform.position = cast.point;

                Vector2 bNormal = cast.normal;

                float angle = Mathf.Atan2(bNormal.y, bNormal.x) * Mathf.Rad2Deg;

                bluePortal.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

                bluePortal.transform.parent = cast.collider.gameObject.transform;

            }
            
        }
    }

    void PlaceOrange()
    {
        if (GameObject.FindWithTag("orangePortal") != null)
        {

            RaycastHit2D cast;
            //print("placed");
            mousePos = (Vector2)Pointer.mousePos;

            //body.velocity = (mousePos - (Vector2)transform.position).normalized * 5;

            cast = Physics2D.Raycast((Vector2)transform.position, (mousePos - (Vector2)transform.position).normalized);


            if (cast.collider != null)
            {
                orangePortal.transform.parent = null;

                orangePortal.transform.position = cast.point;

                Vector2 bNormal = cast.normal;

                float angle = Mathf.Atan2(bNormal.y, bNormal.x) * Mathf.Rad2Deg;

                orangePortal.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

                orangePortal.transform.parent = cast.collider.gameObject.transform;

            }

        }
    }





}
