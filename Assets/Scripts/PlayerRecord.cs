using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    public static int score;
    public static int previousScore;

    public static int maxHealth = 150;
    public static int health;
    public static int previousHealth;

    public static int numberOfLifes = 5;
    public static int previousNumberOfLifes;

    public static int levelsNumber = 5;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        score = 0;
        previousScore = score;
        health = maxHealth;
        previousHealth = health;
    }

    public static int getScore()
    {
        return score;
    }

    public static void setScore(int value)
    {
        score = value;
    }

    public static int getPreviousScore()
    {
        return previousScore;
    }

    public static void setPreviousScore(int value)
    {
        previousScore = value;
    }

}
