﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    private Scene scene;
    private int lastLevel;

    Sprite LampLevel2, LampLevel3, LampLevel4, LampLevel5, LampLevel6, LampLevel8;
    Sprite LampLevel9, LampLevel10, LampLevel11, LampLevel12, LampNone;

    private int time = 0, maxTime = 40;
    private bool showLampInCanvas = true;

    private SoundManager soundManager;
    public ScoreToDisplay scoreToDisplay;

    void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        scene = SceneManager.GetActiveScene();
        lastLevel = DataManager.GetLastLevel();

        //Checking and displaying lamps in magazine:
        if (scene.name.Equals("Magazine"))
        {
            soundManager.playSound("levelChange");
            DisplayLamps();
            showLampInCanvas = true;
        }

        //Setting player position & displaying lamps in levels:
        else if (scene.name.Equals("Corridor"))
        {
            //Get all lamps to test finish scene:
            /*
            DataManager.SetLampLevel(2, true);
            DataManager.SetLampLevel(3, true);
            DataManager.SetLampLevel(4, true);
            DataManager.SetLampLevel(5, true);
            DataManager.SetLampLevel(6, true);
            DataManager.SetLampLevel(8, true);
            DataManager.SetLampLevel(9, true);
            DataManager.SetLampLevel(10, true);
            DataManager.SetLampLevel(11, true);
            DataManager.SetLampLevel(12, true);*/
            
            showLampInCanvas = true;
            switch (lastLevel)
            {
                case 0:
                    GameObject.Find("Player").transform.position = new Vector3(-3104.7f, -251.7f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3104.7f, -233.4f, -10f);
                    break;
                case 1:
                    GameObject.Find("Player").transform.position = new Vector3(-3129.8f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3129.8f, -233.4f, -10f);
                    break;
                case 3:
                    GameObject.Find("Player").transform.position = new Vector3(-3171.4f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3171.4f, -233.4f, -10f);
                    break;
                case 5:
                    GameObject.Find("Player").transform.position = new Vector3(-3236.9f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3236.9f, -233.4f, -10f);
                    break;
                case 7:
                    GameObject.Find("Player").transform.position = new Vector3(-3064.2f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3064.2f, -233.4f, -10f);
                    break;
                case 9:
                    GameObject.Find("Player").transform.position = new Vector3(-3023.2f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-3023.2f, -233.4f, -10f);
                    break;
                case 11:
                    GameObject.Find("Player").transform.position = new Vector3(-2957.7f, -242f, 0);
                    GameObject.Find("Main Camera").transform.position = new Vector3(-2957.7f, -233.4f, -10f);
                    break;
            }
        }
        else if (scene.name.Equals("Level1"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3138.9f, -231.5f, 0);
            }
            else if (lastLevel == 2)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3058.8f, -247.4f, 0);
            }
        }
        else if (scene.name.Equals("Level2"))
        {
            GameObject lamp = GameObject.Find("LampLevel2");
            if (DataManager.GetLampLevel(2) || DataManager.GetLastLampLevel() == 2)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level3"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3130.5f, -225.5f, 0);
            }
            else if (lastLevel == 4)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3062.1f, -218.4f, 0);
            }

            GameObject lamp = GameObject.Find("LampLevel3");
            if (DataManager.GetLampLevel(3) || DataManager.GetLastLampLevel() == 3)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level4"))
        {
            GameObject lamp = GameObject.Find("LampLevel4");
            if (DataManager.GetLampLevel(4) || DataManager.GetLastLampLevel() == 4)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level5"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3140.5f, -247.4f, 0);
            }
            else if (lastLevel == 6)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3061.3f, -247.2f, 0);
            }

            GameObject lamp = GameObject.Find("LampLevel5");
            if (DataManager.GetLampLevel(5) || DataManager.GetLastLampLevel() == 5)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level6"))
        {
            GameObject lamp = GameObject.Find("LampLevel6");
            if (DataManager.GetLampLevel(6) || DataManager.GetLastLampLevel() == 6)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level7"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3138.4f, -247.4f, 0);
            }
            else if (lastLevel == 8)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3061.8f, -213.5f, 0);
            }
        }
        else if (scene.name.Equals("Level8"))
        {
            GameObject lamp = GameObject.Find("LampLevel8");
            if (DataManager.GetLampLevel(8) || DataManager.GetLastLampLevel() == 8)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level9"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3139.6f, -214.9f, 0);
            }
            else if (lastLevel == 10)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3059.8f, -247.6f, 0);
            }

            GameObject lamp = GameObject.Find("LampLevel9");
            if (DataManager.GetLampLevel(9) || DataManager.GetLastLampLevel() == 9)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level10"))
        {
            GameObject lamp = GameObject.Find("LampLevel10");
            if (DataManager.GetLampLevel(10) || DataManager.GetLastLampLevel() == 10)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level11"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3095.8f, -232.4f, 0);
            }
            else if (lastLevel == 12)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3095.8f, -214f, 0);
            }

            GameObject lamp = GameObject.Find("LampLevel11");
            if (DataManager.GetLampLevel(11) || DataManager.GetLastLampLevel() == 11)
            {
                Destroy(lamp);
            }
        }
        else if (scene.name.Equals("Level12"))
        {
            GameObject lamp = GameObject.Find("LampLevel12");
            if (DataManager.GetLampLevel(12) || DataManager.GetLastLampLevel() == 12)
            {
                Destroy(lamp);
            }
        }

        else if (scene.name.Equals("Gap"))
        {
            soundManager.playSound("levelChange");
            exit();
        }

        else if (scene.name.Equals("Menu"))
        {
            DataManager.Clear();
            exit();
        }

        else if (scene.name.Equals("Finish"))
        {
            scoreToDisplay = GameObject.Find("ScoreToDisplay").GetComponent<ScoreToDisplay>();
            scoreToDisplay.setScoreText(PlayerRecord.getScore());
            exit();
        }

        else if (scene.name.Equals("GameOver"))
        {
            exit();
        }

        //Getting all lamps resources:
        LampLevel2 = Resources.Load<Sprite>("lamps/LampLevel2");
        LampLevel3 = Resources.Load<Sprite>("lamps/LampLevel3");
        LampLevel4 = Resources.Load<Sprite>("lamps/LampLevel4");
        LampLevel5 = Resources.Load<Sprite>("lamps/LampLevel5");
        LampLevel6 = Resources.Load<Sprite>("lamps/LampLevel6");
        LampLevel8 = Resources.Load<Sprite>("lamps/LampLevel8");
        LampLevel9 = Resources.Load<Sprite>("lamps/LampLevel9");
        LampLevel10 = Resources.Load<Sprite>("lamps/LampLevel10");
        LampLevel11 = Resources.Load<Sprite>("lamps/LampLevel11");
        LampLevel12 = Resources.Load<Sprite>("lamps/LampLevel12");
        LampNone = Resources.Load<Sprite>("lamps/LampNone");
    }

    public void exit()
    {
        showLampInCanvas = false;
        return;
    }

    public static void DisplayLamps()
    {
        GameObject lamp;
        for (int level = 2; level < 13; level++)
        {
            if (level != 7)
            {
                lamp = GameObject.Find("LampLevel" + level);
                if (DataManager.GetLampLevel(level))
                {
                    lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                }
                else
                {
                    lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(showLampInCanvas)
        {
            int lastLampLevel = DataManager.GetLastLampLevel();
            GameObject lamp = GameObject.Find("LampImage");

            switch (lastLampLevel)
            {
                case 2:
                    lamp.GetComponent<Image>().sprite = LampLevel2;
                    break;
                case 3:
                    lamp.GetComponent<Image>().sprite = LampLevel3;
                    break;
                case 4:
                    lamp.GetComponent<Image>().sprite = LampLevel4;
                    break;
                case 5:
                    lamp.GetComponent<Image>().sprite = LampLevel5;
                    break;
                case 6:
                    lamp.GetComponent<Image>().sprite = LampLevel6;
                    break;
                case 8:
                    lamp.GetComponent<Image>().sprite = LampLevel8;
                    break;
                case 9:
                    lamp.GetComponent<Image>().sprite = LampLevel9;
                    break;
                case 10:
                    lamp.GetComponent<Image>().sprite = LampLevel10;
                    break;
                case 11:
                    lamp.GetComponent<Image>().sprite = LampLevel11;
                    break;
                case 12:
                    lamp.GetComponent<Image>().sprite = LampLevel12;
                    break;
                default:
                    lamp.GetComponent<Image>().sprite = LampNone;
                    break;
            }
        }

        //Displaying gap scene:
        else if (scene.name.Equals("Gap"))
        {
            time++;
            if (time > maxTime)
            {
                int newLevel = DataManager.GetNewLevel();
                switch (newLevel)
                {
                    case 1:
                        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
                        break;
                    case 3:
                        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                        break;
                    case 5:
                        SceneManager.LoadScene("Level5", LoadSceneMode.Single);
                        break;
                    case 7:
                        SceneManager.LoadScene("Level7", LoadSceneMode.Single);
                        break;
                    case 9:
                        SceneManager.LoadScene("Level9", LoadSceneMode.Single);
                        break;
                    case 11:
                        SceneManager.LoadScene("Level11", LoadSceneMode.Single);
                        break;
                    default:
                        SceneManager.LoadScene("Corridor", LoadSceneMode.Single);
                        break;
                }
            }
        }
    }

    public void LoadMagazine()
    {
        // soundManager.audioSrc.Stop();
        //soundManager.audioSrc.loop = false;
        SceneManager.LoadScene("Magazine", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        //soundManager.audioSrc.clip = soundManager.menuMusic;
        //soundManager.audioSrc.loop = true;
        //soundManager.audioSrc.Play();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single); 
    }

    public void SkipGapScene()
    {
        maxTime = 1;
    }
}
