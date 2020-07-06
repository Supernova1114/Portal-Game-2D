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

    private bool flag = true;

    private int count = 4;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VelChecker());
    }

    // Update is called once per frame
    void Update()
    {

    }

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
                yield return new WaitForSeconds(1f);
            }
            else
            {
                text2.text = "";
                count = 4;
            }

            if (count == 0)
            {
                flag = false;
            }

        }

        yield return new WaitForSeconds(0.5f);
        health = 0;
        
    }


}
