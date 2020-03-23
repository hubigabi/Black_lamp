using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreToDisplay : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void setScoreText(int score) {
        text.text = "SCORE: " + score.ToString();
    }
   
}
