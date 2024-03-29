﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPlacer : MonoBehaviour
{

    public GameObject bluePortal;
    public GameObject orangePortal;

    public float portalDecay;

    private bool flagB = true;
    private bool flagO = true;

    public AudioSource aud1;
    public AudioSource aud2;
    public AudioSource aud3;
    public AudioSource aud4;

    //public Rigidbody2D body;

    //RaycastHit2D cast;

    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        bluePortal.SetActive(false);
        orangePortal.SetActive(false);
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


    //places blue portal using a raycast to check pos, and angle of normal.
    void PlaceBlue()
    {
        RaycastHit2D cast;
        //print("placed");
        mousePos = (Vector2)Pointer.mousePos;

        //body.velocity = (mousePos - (Vector2)transform.position).normalized * 5;

        cast = Physics2D.Raycast((Vector2)transform.position, (mousePos - (Vector2)transform.position).normalized);


        if (cast.collider != null)
        {
            bluePortal.SetActive(true);

            bluePortal.transform.parent = null;

            bluePortal.transform.position = cast.point;

            Vector2 bNormal = cast.normal;

            float angle = Mathf.Atan2(bNormal.y, bNormal.x) * Mathf.Rad2Deg;

            bluePortal.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            bluePortal.transform.parent = cast.collider.gameObject.transform;

            aud1.Play();

            if (flagB)
            StartCoroutine(blueTime());

        }
    }


    //places orange portal using a raycast to check pos, and angle of normal.
    void PlaceOrange()
    {
        RaycastHit2D cast;
        //print("placed");
        mousePos = (Vector2)Pointer.mousePos;

        //body.velocity = (mousePos - (Vector2)transform.position).normalized * 5;

        cast = Physics2D.Raycast((Vector2)transform.position, (mousePos - (Vector2)transform.position).normalized);

        if (cast.collider != null)
        {
            orangePortal.SetActive(true);

            orangePortal.transform.parent = null;

            orangePortal.transform.position = cast.point;

            Vector2 bNormal = cast.normal;

            float angle = Mathf.Atan2(bNormal.y, bNormal.x) * Mathf.Rad2Deg;

            orangePortal.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

            orangePortal.transform.parent = cast.collider.gameObject.transform;

            aud2.Play();

            if (flagO)
            StartCoroutine(orangeTime());

        }
    }


    //These 2 Coroutines handle portal decay.
    IEnumerator blueTime()
    {
        flagB = false;
        yield return new WaitForSeconds(portalDecay);
        bluePortal.SetActive(false);
        //aud3.Play();
        flagB = true;
    }

    IEnumerator orangeTime()
    {
        flagO = false;
        yield return new WaitForSeconds(portalDecay);
        orangePortal.SetActive(false);
        //aud4.Play();
        flagO = true;
    }



}
