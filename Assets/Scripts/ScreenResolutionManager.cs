using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolutionManager : MonoBehaviour
{
    
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }


}
