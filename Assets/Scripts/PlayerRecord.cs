using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerRecord 
{
    public static int score = 0;
    public static int previousScore = score;

    public static int maxHealth = 150;
    public static int health = maxHealth;
    public static int previousHealth = health;

    public static int maxNumberOfLifes = 5;
    public static int numberOfLifes = maxNumberOfLifes;
    public static int previousNumberOfLifes;

    public static Dictionary<string, bool> isHeartCollectedInScene = new Dictionary<string, bool>();

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


    public static void restartGame() {
        score = 0;
        health = maxHealth;
        numberOfLifes = maxNumberOfLifes;
        isHeartCollectedInScene.Clear();
    } 
}
