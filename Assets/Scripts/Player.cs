using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private float speed = 20.0f;
    private int health = 200;
    private int damage = 20;

    private Rigidbody2D rb;

    private float leftCameraBorder;
    private float rightCameraBorder;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Start");

        //Camera
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Bounds bounds = new Bounds(Camera.main.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        leftCameraBorder = bounds.center.x - bounds.extents.x;
        rightCameraBorder = bounds.center.x + bounds.extents.x;

        Debug.Log("Bounds: " + bounds);
        Debug.Log("Left camera border:" + leftCameraBorder);
        Debug.Log("Right camera border:" + rightCameraBorder);
    }

  
    void Update()
    {
        var move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, 0);

        if ((CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && Mathf.Abs(rb.velocity.y) < 1.0) {
            rb.AddForce(Vector2.up * 3000);
        }

        transform.position += move * speed * Time.deltaTime;

        //For keyboard
        var moveForKeyboard = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += moveForKeyboard * speed * Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("LeftShoot") || Input.GetKeyDown(KeyCode.K)) {
            FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(), 
                new Vector3(rb.position.x, rb.position.y + 5, 0.0f), Quaternion.identity);

            newFireBall.setDirection(-1);
            newFireBall.setDamage(damage);
            newFireBall.setIsByPlayerCreated(true);
        } else if (CrossPlatformInputManager.GetButtonDown("RightShoot") || Input.GetKeyDown(KeyCode.L)) {
            FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(),
                new Vector3(rb.position.x, rb.position.y + 5, 0.0f), Quaternion.identity);

            newFireBall.setDirection(1);
            newFireBall.setDamage(damage);
            newFireBall.setIsByPlayerCreated(true);
        }

        

        if (transform.position.x < leftCameraBorder)
        {
            transform.position = new Vector3(leftCameraBorder, transform.position.y, transform.position.z);

        }

        if (transform.position.x > rightCameraBorder)
        {
            transform.position = new Vector3(rightCameraBorder, transform.position.y, transform.position.z);
        }

        if (health <= 0) {
            Destroy(gameObject);
            Debug.Log("Death of player");
        }

    }

    public float getSpeed() {
        return speed;
    }

    public void setSpeed(float value){
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
