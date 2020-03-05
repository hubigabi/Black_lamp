using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    private float speed = 40.0f;
    private int direction = 0;

    private int health = 25;
    private int damage = 15;

    private float leftBorder;
    private float rightBorder;

    private float topCameraBorder;
    //private float bottomCameraBorder;
    private float groundTopY;

    private float height;
    private bool isFlyingDown = true;


    private double countTime = 0.0;
    private double timeToCreateNewFireBall;

    public void setDirection(int value)
    {
        direction = value;
    }

    void Start()
    {
        timeToCreateNewFireBall = Random.Range(1.0f, 1.5f);

        leftBorder = GameObject.Find("LeftBorder").transform.position.x;
        rightBorder = GameObject.Find("RightBorder").transform.position.x;
        height = GameObject.Find("Enemy3").GetComponent<Enemy3>().GetComponent<SpriteRenderer>().bounds.size.y;

        //Camera
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Bounds bounds = new Bounds(Camera.main.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        topCameraBorder = bounds.center.y + bounds.extents.y;
        //bottomCameraBorder = bounds.center.y - bounds.extents.y;
        Debug.Log("Top camera border: " + topCameraBorder);
        //Debug.Log("Bottom camera border: " + bottomCameraBorder);

        groundTopY = GameObject.Find("Ground").transform.position.y + GameObject.Find("Ground").GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }


    void Update()
    {
        if (direction != 0)
        {
            transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;

            if (transform.position.x < leftBorder || transform.position.x > rightBorder)
            {
                int yDirection = 0;
                if (isFlyingDown)
                {
                    yDirection = -1;
                }
                else
                {
                    yDirection = 1;
                }

                if (Random.Range(0, 2) == 0)
                {

                    transform.position = new Vector3(rightBorder, transform.position.y + yDirection * height, transform.position.z);
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                    direction = -1;
                }
                else
                {
                    transform.position = new Vector3(leftBorder, transform.position.y + yDirection * height, transform.position.z);
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                    direction = 1;
                }
            }


            if (transform.position.y - height / 2 < groundTopY || transform.position.y + height / 2 > topCameraBorder)
            {
                if (Random.Range(0, 2) == 0)
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        transform.position = new Vector3(rightBorder, topCameraBorder - height / 2, transform.position.z);
                        transform.rotation = new Quaternion(0, 180, 0, 0);
                        direction = -1;
                    }
                    else
                    {
                        transform.position = new Vector3(leftBorder, topCameraBorder - height / 2, transform.position.z);
                        transform.rotation = new Quaternion(0, 0, 0, 0);
                        direction = 1;
                    }
                    isFlyingDown = true;
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        transform.position = new Vector3(rightBorder, groundTopY + height / 2, transform.position.z);
                        transform.rotation = new Quaternion(0, 180, 0, 0);
                        direction = -1;
                    }
                    else
                    {
                        transform.position = new Vector3(leftBorder, groundTopY + height / 2, transform.position.z);
                        transform.rotation = new Quaternion(0, 0, 0, 0);
                        direction = 1;
                    }
                    isFlyingDown = false;
                }
            }



            //Fireballs
            countTime += Time.deltaTime;
            if (countTime > timeToCreateNewFireBall && direction != 0)
            {
                FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(),
                         new Vector3(transform.position.x, transform.position.y, 0.0f), Quaternion.identity);

                newFireBall.setDirection(direction);
                newFireBall.setDamage(damage);
                newFireBall.setIsByPlayerCreated(false);
                newFireBall.changeSpriteOnBlueBall();
                newFireBall.setSpeed(getSpeed() * 1.5f);

                countTime = 0.0;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Death of enemy");
            }
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("Collison with Player");

            Player player = col.gameObject.GetComponent<Player>();
            player.setHealth(player.getHealth() - damage);
            Debug.Log("Life of player: " + player.getHealth());
        }


    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float value)
    {
        speed = value;
    }

    public int getHealth()
    {
        return health;
    }

    public void setHealth(int value)
    {
        health = value;
    }

    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int value)
    {
        damage = value;
    }

    public bool getIsFlyingDown()
    {
        return isFlyingDown;
    }

    public void setIsFlyingDown(bool value)
    {
        isFlyingDown = value;
    }

}
