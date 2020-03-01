using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private float speed = 20.0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        var move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, 0);

        if ((CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && Mathf.Abs(rb.velocity.y) < 1.0) {
            rb.AddForce(Vector2.up * 2500);
        }

        transform.position += move * speed * Time.deltaTime;

        //For keyboard
        var moveForKeyboard = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += moveForKeyboard * speed * Time.deltaTime;

        if (CrossPlatformInputManager.GetButtonDown("LeftShoot") || Input.GetKeyDown(KeyCode.K)) {
            FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(), 
                new Vector3(rb.position.x, rb.position.y + 5, 0.0f), Quaternion.identity);

            newFireBall.setDirection(-1);
        } else if (CrossPlatformInputManager.GetButtonDown("RightShoot") || Input.GetKeyDown(KeyCode.L)) {
            FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(),
                new Vector3(rb.position.x, rb.position.y + 5, 0.0f), Quaternion.identity);

            newFireBall.setDirection(1);
        }

    }
}
