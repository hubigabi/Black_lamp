using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private float leftBorderX;
    private float rightBorderX;

    private float topCameraBorder;
    private float groundTopY;

    private float enemy1Height;
    private float enemy2Height;
    private float enemy3Height;
    private float enemy4Height;

    private double countTime = 0.0;
    private double timeToCreateNewEnemy;

    private int maxNumberOfEnemies = 6;

    void Start()
    {
        timeToCreateNewEnemy = Random.Range(3.0f, 5.0f); 
        leftBorderX = GameObject.Find("LeftBorder").transform.position.x;
        rightBorderX = GameObject.Find("RightBorder").transform.position.x;

        //Camera
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Bounds bounds = new Bounds(Camera.main.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        topCameraBorder = bounds.center.y + bounds.extents.y;

        groundTopY = GameObject.Find("Ground").GetComponent<SpriteRenderer>().bounds.size.y/2 + GameObject.Find("Ground").transform.position.y;
        Debug.Log("Ground Y: " + groundTopY);

        enemy1Height = GameObject.Find("Enemy1").GetComponent<Enemy1>().GetComponent<SpriteRenderer>().bounds.size.y;
        enemy2Height = GameObject.Find("Enemy2").GetComponent<Enemy2>().GetComponent<SpriteRenderer>().bounds.size.y;
        enemy3Height = GameObject.Find("Enemy3").GetComponent<Enemy3>().GetComponent<SpriteRenderer>().bounds.size.y;
        enemy4Height = GameObject.Find("Enemy4").GetComponent<Enemy4>().GetComponent<SpriteRenderer>().bounds.size.y;
    
        createEnemy1();
        //createEnemy2();
        createEnemy3();
        createEnemy4();
    }

    void Update()
    {
        countTime += Time.deltaTime;
        if (countTime > timeToCreateNewEnemy) {

            int randomNumber = Random.Range(0, 5);

            //Not so difficult, number of enemies cant be infinite 
            if (getNumberOfEnemies() < maxNumberOfEnemies)
            {
                if (randomNumber == 0)
                {
                    createEnemy1();
                }
                else if (randomNumber == 1)
                {
                    createEnemy2();
                }
                else if (randomNumber == 3)
                {
                    createEnemy3();
                }
                else if (randomNumber == 4)
                {
                    createEnemy4();
                }
            }

            countTime = 0.0;
            timeToCreateNewEnemy = Random.Range(1.5f, 2.0f);
        }

    }

    public void createEnemy1() {

        if (Random.Range(0, 2) == 0)
        {
            Enemy1 enemy1 = Instantiate(GameObject.Find("Enemy1").GetComponent<Enemy1>(),
               new Vector3(leftBorderX, groundTopY + enemy1Height/2, 0.0f), Quaternion.identity);

            enemy1.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy1.setDirection(1);
        }
        else
        {
            Enemy1 enemy1 = Instantiate(GameObject.Find("Enemy1").GetComponent<Enemy1>(),
               new Vector3(rightBorderX, groundTopY + enemy1Height / 2, 0.0f), Quaternion.identity);

            enemy1.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy1.setDirection(-1);
        }

    }


    public void createEnemy2()
    {

        if (Random.Range(0, 2) == 0)
        {
            Enemy2 enemy2 = Instantiate(GameObject.Find("Enemy2").GetComponent<Enemy2>(),
               new Vector3(leftBorderX, groundTopY + enemy2Height / 2, 0.0f), Quaternion.identity);

            enemy2.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy2.setDirection(1);
        }
        else
        {
            Enemy2 enemy2 = Instantiate(GameObject.Find("Enemy2").GetComponent<Enemy2>(),
               new Vector3(rightBorderX, groundTopY + enemy2Height / 2, 0.0f), Quaternion.identity);

            enemy2.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy2.setDirection(-1);
        }

    }

    public void createEnemy3()
    {
        float initialeYPosition = Random.Range(groundTopY + enemy3Height, topCameraBorder - enemy3Height);

        if (Random.Range(0, 2) == 0)
        {
            Enemy3 enemy3 = Instantiate(GameObject.Find("Enemy3").GetComponent<Enemy3>(),
               new Vector3(leftBorderX, initialeYPosition, 0.0f), Quaternion.identity);

            enemy3.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy3.setDirection(1);
        }
        else
        {
            Enemy3 enemy3 = Instantiate(GameObject.Find("Enemy3").GetComponent<Enemy3>(),
               new Vector3(rightBorderX, groundTopY + initialeYPosition, 0.0f), Quaternion.identity);

            enemy3.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy3.setDirection(-1);
        }
    }

    public void createEnemy4()
    {
        float initialeYPosition = Random.Range(groundTopY + enemy4Height , topCameraBorder - enemy4Height);

        if (Random.Range(0, 2) == 0)
        {
            Enemy4 enemy4 = Instantiate(GameObject.Find("Enemy4").GetComponent<Enemy4>(),
               new Vector3(leftBorderX, initialeYPosition, 0.0f), Quaternion.identity);

            enemy4.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy4.setDirection(1);
        }
        else
        {
            Enemy4 enemy4 = Instantiate(GameObject.Find("Enemy4").GetComponent<Enemy4>(),
               new Vector3(rightBorderX, groundTopY + initialeYPosition, 0.0f), Quaternion.identity);

            enemy4.transform.rotation = new Quaternion(0, 180, 0, 0);
            enemy4.setDirection(-1);
        }
    }

    public int getNumberOfEnemies() {
        return GameObject.FindGameObjectsWithTag("Enemy1").Length
        + GameObject.FindGameObjectsWithTag("Enemy2").Length
        + GameObject.FindGameObjectsWithTag("Enemy3").Length
        + GameObject.FindGameObjectsWithTag("Enemy4").Length
        //-4, beacsue they are one prototype for each enemy
        - 4; 
    }

}
