using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationHandlerBlue : MonoBehaviour
{
    private GameObject orangePortal;

    public bool flag = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( flag ) 
        {
            orangePortal.GetComponent<TeleportationHandlerOrange>().flag = false;

            collision.gameObject.transform.position = orangePortal.transform.position;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        flag = true;
    }

}
