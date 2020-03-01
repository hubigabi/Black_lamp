using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float speed = 50.0f;
    private int direction = 0;

    private float leftBorder;
    private float rightBorder;

    public void setDirection(int value) {
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

        if (transform.position.x < leftBorder || transform.position.x > rightBorder) {
            Destroy(gameObject);
        }
    
    }
}
