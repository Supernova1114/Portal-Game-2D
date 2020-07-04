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

    // Start is called before the first frame update
    void Start()
    {
        
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

}
