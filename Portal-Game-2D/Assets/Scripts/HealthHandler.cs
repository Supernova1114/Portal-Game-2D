using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthHandler : MonoBehaviour
{

    public float health;
    public float reductionAmount;
    public Text text;

    private bool isAlive = true;
    public Rigidbody2D body;

    public Text text2;
    public Text text3;

    private bool flag = true;

    private int count = 4;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VelChecker());
    }



    //handles health reduction when touching enemy
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isAlive)
        {
            if (collision.gameObject.tag == "bad")
            {
                health = health - reductionAmount;

                //print(health);
                text.text = ((int)health).ToString();

                if (health < 0)
                {
                    isAlive = false;
                    SceneManager.LoadScene(sceneName: "Death");
                    //print("dead");
                }
            }
        }
    }


    //Checks velocity and then counts down.
    IEnumerator VelChecker()
    {

        yield return new WaitForSeconds(3);

        while ( flag )
        {
            yield return new WaitForSeconds(0.0f);
            if (  Mathf.Abs(body.velocity.x) < 0.7f && Mathf.Abs(body.velocity.y) < 0.7f )
            {
               
                count--;
                text2.text = count.ToString();
                text3.text = "Keep Moving!";
                yield return new WaitForSeconds(1f);
            }
            else
            {
                count = 4;
                text2.text = "";
                text3.text = "";
            }

            if (count == 0)
            {
                flag = false;
            }

        }

        yield return new WaitForSeconds(0.5f);
        health = 0;
        
    }


    private void OnBecameInvisible()
    {
        health = 0;
    }


}
