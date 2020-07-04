using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinalScore : MonoBehaviour
{
    public Text text;
    private int finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore = ScoreHandler.score;
        text.text = finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
