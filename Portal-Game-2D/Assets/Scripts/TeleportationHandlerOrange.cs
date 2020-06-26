using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerOrange : MonoBehaviour
{
    private GameObject bluePortal;

    public bool isInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        bluePortal = GameObject.FindGameObjectWithTag("bluePortal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2 vect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInProgress = true;

        if ( !(bluePortal.GetComponent<TeleportationHandlerBlue>().isInProgress) )
        {
            vect = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

            collision.gameObject.transform.position = bluePortal.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bluePortal.GetComponent<TeleportationHandlerBlue>().isInProgress = false;
    }

}
