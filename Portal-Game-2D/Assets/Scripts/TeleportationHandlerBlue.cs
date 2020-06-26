using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerBlue : MonoBehaviour
{
    private GameObject orangePortal;

    public bool isInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        orangePortal = GameObject.FindGameObjectWithTag("orangePortal");
        //GameObject.Find("Companion Cube").GetComponent<Rigidbody2D>().velocity = new Vector2( 3, 10 );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 vect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInProgress = true;

        if (!(orangePortal.GetComponent<TeleportationHandlerOrange>().isInProgress))
        {
            vect = collision.gameObject.GetComponent<Rigidbody2D>().velocity;

            collision.gameObject.transform.position = orangePortal.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        orangePortal.GetComponent<TeleportationHandlerOrange>().isInProgress = false;
    }


}
