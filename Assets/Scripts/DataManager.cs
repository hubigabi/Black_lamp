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
}
