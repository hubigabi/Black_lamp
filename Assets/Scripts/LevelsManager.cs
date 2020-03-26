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
        //Checking last level & setting position:
        scene = SceneManager.GetActiveScene();
        lastLevel = DataManager.GetLastLevel();

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
