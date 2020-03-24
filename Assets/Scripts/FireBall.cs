using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float speed = 60.0f;
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
            PlayerRecord.health -= damage;
            //Debug.Log("Life of player: " + PlayerRecord.health);
        } else if (isByPlayerCreated) {

            if (col.gameObject.tag.Equals("Enemy1")) {
                Debug.Log("Collison with Enemy1");

                Enemy1 enemy1 = col.gameObject.GetComponent<Enemy1>();
                enemy1.setHealth(enemy1.getHealth() - damage);
               //Debug.Log("Life of Enemy1: " + enemy1.getHealth());
            }

            else if (col.gameObject.tag.Equals("Enemy2"))
            {
                Debug.Log("Collison with Enemy2");

                Enemy2 enemy2 = col.gameObject.GetComponent<Enemy2>();
                enemy2.setHealth(enemy2.getHealth() - damage);
                //Debug.Log("Life of Enemy2: " + enemy2.getHealth());
            }
            else if (col.gameObject.tag.Equals("Enemy3"))
            {
                Debug.Log("Collison with Enemy3");

                Enemy3 enemy3 = col.gameObject.GetComponent<Enemy3>();
                enemy3.setHealth(enemy3.getHealth() - damage);
                //Debug.Log("Life of Enemy3: " + enemy3.getHealth());
            }
            else if (col.gameObject.tag.Equals("Enemy4"))
            {
                Debug.Log("Collison with Enemy4");

                Enemy4 enemy4 = col.gameObject.GetComponent<Enemy4>();
                enemy4.setHealth(enemy4.getHealth() - damage);
                //Debug.Log("Life of Enemy4: " + enemy4.getHealth());
            }
        }  else if (col.gameObject.tag.Equals("FireBall"))
        {
            bool isByPlayerCreatedColFireBall = col.gameObject.GetComponent<FireBall>().getIsByPlayerCreated();
            if (isByPlayerCreated ^ isByPlayerCreatedColFireBall) {
                //Debug.Log("Fireball is destroyed");
                Destroy(col.gameObject);
                Destroy(gameObject); }
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
