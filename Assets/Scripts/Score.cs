using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void changeScore(int score) {
        scoreText.text = "HIGH SCORE: " + score.ToString();
    }
   
}
