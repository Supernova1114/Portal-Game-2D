using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Controller : MonoBehaviour
{
    float horz;
    float vert;
    public float hForce;
    public float vForce;

    public float maxSpeed;
    public float maxJump;

    public Rigidbody2D body;

    private bool isTouchingWall = false;
    //float vert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vert = Input.GetAxisRaw("Vertical");
        horz = Input.GetAxisRaw("Horizontal");


        Move(horz, vert);
        print(body.velocity);
    }

    void Move(float h, float v)
    {

        //body.velocity = new Vector2( h*speed*Time.deltaTime, v*jumpNum*Time.deltaTime );

        /*if ( body.velocity.x < maxSpeed || body.velocity.x > -maxSpeed )*/
        body.AddForce(new Vector2(h * hForce * Time.deltaTime, v * vForce * Time.deltaTime));

        if ( body.velocity.magnitude > maxSpeed)
        {
            body.velocity = new Vector2(body.velocity.normalized.x*maxSpeed, body.velocity.normalized.y*maxSpeed);
        }

        

        /*if ( isTouchingWall)
        {
            if ( v < 0 )
            body.AddForce(new Vector2( 0, (v*jumpNum)*Time.deltaTime ));
        }*/
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "wall")
        {
            isTouchingWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            isTouchingWall = false;
        }
    }*/
}
