using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static int lastLevel = 0;

    public static int GetLastLevel()
    {
        return lastLevel;
    }

    public static void SetLastLevel(int value)
    {
        lastLevel = value;
    }

    private static bool[] LampLevel = new bool[13];
    private static int LastLampLevel;
    
    public static bool GetLampLevel(int level)
    {
        return LampLevel[level];
    }

    public static void SetLampLevel(int level, bool value)
    {
        LampLevel[level] = value;
    }

    public static int GetLastLampLevel()
    {
        return LastLampLevel;
    }

    public static void SetLastLampLevel(int value)
    {
        LastLampLevel = value;
    }

    public static bool CheckAll()
    {
        for(int i = 2; i < 13; i++)
        {
            if(i != 7 && LampLevel[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    private static int newLevel = 0;

    public static int GetNewLevel()
    {
        return newLevel;
    }

    public static void SetNewLevel(int value)
    {
        newLevel = value;
    }

    public static void Clear()
    {
        lastLevel = 0;
        for (int i = 0; i < 13; i++)
        {
            LampLevel[i] = false;
        }
        LastLampLevel = 0;
        newLevel = 0;
    }
}
