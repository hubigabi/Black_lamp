using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private float leftBorderX;
    private float rightBorderX;
    private float groundY;

    private float enemy1Height;
    private float enemy2Height;

    private double countTime = 0.0;
    private double timeToCreateNewEnemy;

    void Start()
    {
        timeToCreateNewEnemy = Random.Range(4.0f, 8.0f); ;
        leftBorderX = GameObject.Find("LeftBorder").transform.position.x;
        rightBorderX = GameObject.Find("RightBorder").transform.position.x;

        groundY = GameObject.Find("Ground").GetComponent<SpriteRenderer>().bounds.size.y/2 + GameObject.Find("Ground").transform.position.y;
        Debug.Log("Ground Y: " + groundY);

        enemy1Height = GameObject.Find("Enemy1").GetComponent<Enemy1>().GetComponent<SpriteRenderer>().bounds.size.y;
        enemy2Height = GameObject.Find("Enemy2").GetComponent<Enemy2>().GetComponent<SpriteRenderer>().bounds.size.y;
    
        createEnemy1();
        createEnemy2();
    }

    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime > timeToCreateNewEnemy) {

            int randomNumber = Random.Range(0, 2);

            if (randomNumber == 0)
            {
                createEnemy1();
            }  else if (randomNumber == 1){
                createEnemy2();
            }

            countTime = 0.0;
        }

    }

    public void createEnemy1() {

        if (Random.Range(0, 2) == 0)
        {
            Enemy1 enemy1 = Instantiate(GameObject.Find("Enemy1").GetComponent<Enemy1>(),
               new Vector3(leftBorderX, groundY + enemy1Height/2, 0.0f), Quaternion.identity);

            enemy1.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy1.setDirection(1);
        }
        else
        {
            Enemy1 enemy1 = Instantiate(GameObject.Find("Enemy1").GetComponent<Enemy1>(),
               new Vector3(rightBorderX, groundY + enemy1Height / 2, 0.0f), Quaternion.identity);

            enemy1.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy1.setDirection(-1);
        }

    }


    public void createEnemy2()
    {

        if (Random.Range(0, 2) == 0)
        {
            Enemy2 enemy2 = Instantiate(GameObject.Find("Enemy2").GetComponent<Enemy2>(),
               new Vector3(leftBorderX, groundY + enemy1Height / 2, 0.0f), Quaternion.identity);

            enemy2.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy2.setDirection(1);
        }
        else
        {
            Enemy2 enemy2 = Instantiate(GameObject.Find("Enemy2").GetComponent<Enemy2>(),
               new Vector3(rightBorderX, groundY + enemy1Height / 2, 0.0f), Quaternion.identity);

            enemy2.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy2.setDirection(-1);
        }

    }

}
