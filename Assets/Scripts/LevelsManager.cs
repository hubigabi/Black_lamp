using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    private Scene scene;
    private int lastLevel;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        lastLevel = DataManager.GetLastLevel();

        //Checking and displaying lamps in magazine:
        if (scene.name.Equals("Magazine"))
        {
            DisplayLamps();
        }

        //Setting player position & displaying lamps in levels:
        if (scene.name.Equals("Corridor"))
        {
            if (lastLevel == 0)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3104.7f, -251.7f, 0);
            }
            else if (lastLevel == 1)
            {
                GameObject.Find("Player").transform.position = new Vector3(-3129.8f, -248f, 0);
            }
            else if (lastLevel == 3)
            {
                GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-3171.4f, -248f, 0);
            }
            else if (lastLevel == 5)
            {
                GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-3236.9f, -248f, 0);
            }
            else if (lastLevel == 7)
            {
                GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-3064.2f, -248f, 0);
            }
            else if (lastLevel == 9)
            {
                GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-3023.2f, -248f, 0);
            }
            else if (lastLevel == 11)
            {
                GameObject.Find("Player").GetComponent<Transform>().position = new Vector3(-2957.7f, -248f, 0);
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (scene.name.Equals("Level4"))
        {
            GameObject lamp = GameObject.Find("LampLevel4");
            if (DataManager.GetLampLevel(4) || DataManager.GetLastLampLevel() == 4)
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (scene.name.Equals("Level6"))
        {
            GameObject lamp = GameObject.Find("LampLevel6");
            if (DataManager.GetLampLevel(6) || DataManager.GetLastLampLevel() == 6)
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (scene.name.Equals("Level10"))
        {
            GameObject lamp = GameObject.Find("LampLevel10");
            if (DataManager.GetLampLevel(10) || DataManager.GetLastLampLevel() == 10)
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
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
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        else if (scene.name.Equals("Level12"))
        {
            GameObject lamp = GameObject.Find("LampLevel12");
            if (DataManager.GetLampLevel(12) || DataManager.GetLastLampLevel() == 12)
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 0;
                lamp.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                lamp.GetComponent<SpriteRenderer>().sortingOrder = 3;
                lamp.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
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

    }

    public void LoadMagazine()
    {
       SceneManager.LoadScene("Magazine", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
