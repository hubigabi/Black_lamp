using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;

    public void changeVisibleHeartsNumber(int visibleHeartsNumber){
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < visibleHeartsNumber) {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void removeOneHeart(int heartNumber) {
        hearts[heartNumber].enabled = false;
    }
}
