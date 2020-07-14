using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAttack : MonoBehaviour
{
    public Rigidbody2D body;
    public static bool run = true;
    //private Vector2 vel;
    public float moveSpeed;

    GameObject player;

    public AudioSource aud1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Companion Cube");
        StartCoroutine(StartFollow());
    }



    //Makes obj follow player
    IEnumerator StartFollow()
    {
        while (run)
        {

            yield return new WaitForSeconds(0.5f);
            for ( int i = 0; i < 1; i++)
            {
                body.velocity = (Vector2)(player.transform.position - transform.position).normalized * moveSpeed;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.tag == "wall" )
        aud1.Play();
    }


}
