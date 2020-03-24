using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    private double countTime = 0.0;

    [SerializeField]
    private float timeToAppearDoor;

    [SerializeField]
    private float timeToOpenDoor;

    [SerializeField]
    private float deltaTime;

    [SerializeField]
    private Sprite spriteAppearedDoor;

    [SerializeField]
    private Sprite spriteOpenedDoor;

    private int counter = 0;

    private Scene currentScene;

    void Start()
    {
        Debug.Log("Number of sccenes:" + SceneManager.GetAllScenes().Length);
        GetComponent<Renderer>().enabled = false;
        timeToAppearDoor = Random.Range(timeToAppearDoor - deltaTime, timeToAppearDoor + deltaTime);
        timeToOpenDoor = Random.Range(timeToOpenDoor - deltaTime, timeToOpenDoor + deltaTime);
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        countTime += Time.deltaTime;

        if (counter == 0)
        {
            if (countTime > timeToAppearDoor)
            {
                GetComponent<Renderer>().enabled = true;
                GetComponent<SpriteRenderer>().sprite = spriteAppearedDoor;
                counter = 1;
            }
        } else if(counter == 1){
            if (countTime > timeToOpenDoor)
            {
                GetComponent<Renderer>().enabled = true;
                GetComponent<SpriteRenderer>().sprite = spriteOpenedDoor;
                counter = 2;
            }
        }


    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.name.Equals("Player") && counter == 2)
        {
            if (currentScene.buildIndex+1 < PlayerRecord.levelsNumber)
            {
                Debug.Log("Load next level");
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            }
            else {
                Debug.Log("You finished the game!");
            }
        }


    }

}
