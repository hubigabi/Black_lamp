using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private float speed = 30.0f;
    private int direction = 1;

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
        Debug.Log("Start");
    }


    void Update()
    {
        transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;

        if (transform.position.x < leftBorder )
        {
            transform.position = new Vector3(rightBorder, transform.position.y, transform.position.z);
        
        }

        if (transform.position.x > rightBorder)
        {
            transform.position = new Vector3(leftBorder, transform.position.y, transform.position.z);
        }
  
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collison");
        Destroy(gameObject);
    }

}
