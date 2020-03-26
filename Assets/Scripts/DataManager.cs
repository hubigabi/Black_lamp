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
}
