using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerOrange : MonoBehaviour
{
    private GameObject bluePortal;

    public bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        bluePortal = GameObject.FindGameObjectWithTag("bluePortal");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( flag )
        {
            bluePortal.GetComponent<TeleportationHandlerBlue>().flag = false;
            collision.gameObject.transform.position = bluePortal.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = true;
    }

}
