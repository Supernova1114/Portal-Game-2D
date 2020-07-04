using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public Text text;

    bool flag = true;

    void Start()
    {
        score = 0;
        StartCoroutine(ScoreCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ScoreCounter()
    {
        while (flag == true)
        {
            yield return new WaitForSeconds(0.1f);
            score++;
            text.text = score.ToString();
        }
        
    }

}
