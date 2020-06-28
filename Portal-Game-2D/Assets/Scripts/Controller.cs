using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Controller : MonoBehaviour
{
    private float horz;
    private float vert;

    public float hForce;
    public float vForce;
    public float maxSpeed;
    public float normVForce;

    private bool onWall = false;
    //private bool jump = false;

    public Rigidbody2D body;

    //float vert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");

    }
    void FixedUpdate()
    {
        
        Move(horz, vert);
        //print("vel" body.velocity);
    }

    float temp;
    float velX;
    void Move(float h, float v)
    {

        //body.velocity = new Vector2( h*speed*Time.deltaTime, v*jumpNum*Time.deltaTime );

        /*if ( body.velocity.x < maxSpeed || body.velocity.x > -maxSpeed )*/
        body.AddForce(new Vector2(h * hForce * Time.deltaTime, 0));

        

        if ( Mathf.Abs(body.velocity.x) > maxSpeed)
        {
            temp = body.velocity.x;

            if ( temp < 0)
            {
                velX = -1;
            }
            else
            {
                velX = 1;
            }

            body.velocity = new Vector2( velX*maxSpeed, body.velocity.y );
        }





        if (onWall && v == 1)
        {
            body.AddForce(new Vector2(0, vForce*Time.deltaTime));
        }

        if (onWall)
        {
            body.AddForce(new Vector2(0, normVForce * Time.deltaTime));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            onWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            onWall = false;
        }
    }
}
