using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private float speed = 30.0f;
    private int direction = 0;

    private int health = 100;
    private int damage = 25;

    private float leftBorder;
    private float rightBorder;

    public void setDirection(int value)
    {
        direction = value;
    }

    void Start()
    {
        leftBorder = GameObject.Find("LeftBorder").transform.position.x;
        rightBorder = GameObject.Find("RightBorder").transform.position.x;
    }


    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;

        if (transform.position.x < leftBorder || transform.position.x > rightBorder)
        {
            if (Random.Range(0, 2) == 0)
            {

                transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
                transform.rotation = new Quaternion(0, 180, 0, 0);
                direction = -1;
            }
            else
            {
                transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
                transform.rotation = new Quaternion(0, 0, 0, 0);
                direction = 1;
            }

        }

   

        if (health <= 0)
        {
            Destroy(gameObject);
            Player.score += damage * 10;
            Debug.Log("Death of enemy");
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.name.Equals("Player")){
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

}
