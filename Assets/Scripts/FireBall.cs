﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float speed = 50.0f;
    private int direction = 0;

    private int damage = 1;
    private bool isByPlayerCreated = true;

    private float leftBorder;
    private float rightBorder;

    void Start()
    {
        leftBorder = GameObject.Find("LeftBorder").transform.position.x;
        rightBorder = GameObject.Find("RightBorder").transform.position.x;
    }


    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;

        if (transform.position.x < leftBorder || transform.position.x > rightBorder) {
            Destroy(gameObject);
        }
    
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Player") && !isByPlayerCreated)
        {
            Debug.Log("Collison with Player");

            Player player = col.gameObject.GetComponent<Player>();
            player.setHealth(player.getHealth() - damage);
            Debug.Log("Life of player: " + player.getHealth());
        } else if (isByPlayerCreated) {

            if (col.gameObject.tag.Equals("Enemy1")) {
                Debug.Log("Collison with Enemy1");

                Enemy1 enemy1 = col.gameObject.GetComponent<Enemy1>();
                enemy1.setHealth(enemy1.getHealth() - damage);
                Debug.Log("Life of Enemy1: " + enemy1.getHealth());
            }

            else if (col.gameObject.tag.Equals("Enemy2"))
            {
                Debug.Log("Collison with Enemy2");

                Enemy2 enemy2 = col.gameObject.GetComponent<Enemy2>();
                enemy2.setHealth(enemy2.getHealth() - damage);
                Debug.Log("Life of Enemy2: " + enemy2.getHealth());
            }
        }  else if (col.gameObject.tag.Equals("FireBall"))
        {
            Debug.Log("Fireball is destroyed");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }


    }

    public void changeSpriteOnBlueBall() {
        GetComponent<SpriteRenderer>().sprite = GameObject.Find("BlueBallSprite").GetComponent<SpriteRenderer>().sprite;
    }

    public int getDirection()
    {
        return direction;
    }

    public void setDirection(int value)
    {
        direction = value;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float value)
    {
        speed = value;
    }


    public int getDamage()
    {
        return damage;
    }

    public void setDamage(int value)
    {
        damage = value;
    }

    public bool getIsByPlayerCreated()
    {
        return isByPlayerCreated;
    }

    public void setIsByPlayerCreated(bool value)
    {
        isByPlayerCreated = value;
    }

}
