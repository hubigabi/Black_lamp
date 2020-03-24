using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private float speed = 20.0f;
    private int damage = 20;

    private float height;
    private float width;

    private Rigidbody2D rb;

    private float leftCameraBorder;
    private float rightCameraBorder;

    public HealthBar healthBar;

    public ScoreToDisplay scoreToDisplay;

    public HeartManager heartManager;

    public Animator animator;
    public bool waitingForDeath = false;

    private bool isJumping = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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

        scoreToDisplay.setScoreText(PlayerRecord.getScore());
        PlayerRecord.setPreviousScore(PlayerRecord.getScore());

        healthBar.SetMaxHealth(PlayerRecord.maxHealth);
        healthBar.SetHealth(PlayerRecord.health);
        PlayerRecord.previousHealth = PlayerRecord.health;

        heartManager.changeVisibleHeartsNumber(PlayerRecord.numberOfLifes);
        PlayerRecord.previousNumberOfLifes = PlayerRecord.numberOfLifes;

        height = GameObject.Find("Player").GetComponent<Player>().GetComponent<SpriteRenderer>().bounds.size.y;
        width = GameObject.Find("Player").GetComponent<Player>().GetComponent<SpriteRenderer>().bounds.size.x;

        //Free rotatation along Z-axis
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    void Update()
    {
        if (!waitingForDeath)
        {
            var move = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, 0);

            if ((CrossPlatformInputManager.GetButton("Jump") || Input.GetButton("Jump")) && !isJumping)
            {
                rb.AddForce(Vector2.up * 2900);
                animator.SetBool("isJumping", true);
                isJumping = true;
            }

            transform.position += move * speed * Time.deltaTime;

            //For keyboard
            var moveForKeyboard = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += moveForKeyboard * speed * Time.deltaTime;

            if (Mathf.Abs(move.x) >= Mathf.Abs(moveForKeyboard.x) && move.x != 0)
            {
                animator.SetFloat("speed", Mathf.Abs(move.x));

                if (move.x < 0)
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                else if (move.x > 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }

            }
            else if (moveForKeyboard.x != 0)
            {
                animator.SetFloat("speed", Mathf.Abs(moveForKeyboard.x));

                if (moveForKeyboard.x < 0)
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                else if (moveForKeyboard.x > 0)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
            else
            {
                animator.SetFloat("speed", 0.0f);
            }

            if (CrossPlatformInputManager.GetButtonDown("Shoot") || Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("isShooting", true);
                int direction = -1;
                float offset = -width / 10;

                if (transform.rotation.y == 0)
                {
                    direction = 1;
                    offset *= -1;
                }


                FireBall newFireBall = Instantiate(GameObject.FindGameObjectsWithTag("FireBall")[0].GetComponent<FireBall>(),
                    new Vector3(rb.position.x + offset, rb.position.y + height / 6, 0.0f), Quaternion.identity);

                newFireBall.setDirection(direction);
                newFireBall.setDamage(damage);
                newFireBall.setIsByPlayerCreated(true);
            }
            else
            {
                animator.SetBool("isShooting", false);
            }



            if (transform.position.x < leftCameraBorder)
            {
                transform.position = new Vector3(leftCameraBorder, transform.position.y, transform.position.z);

            }

            if (transform.position.x > rightCameraBorder)
            {
                transform.position = new Vector3(rightCameraBorder, transform.position.y, transform.position.z);
            }

            if (PlayerRecord.health != PlayerRecord.previousHealth)
            {
                healthBar.SetHealth(PlayerRecord.health);
                PlayerRecord.previousHealth = PlayerRecord.health;
            }

            if (PlayerRecord.getScore() != PlayerRecord.getPreviousScore())
            {
                scoreToDisplay.setScoreText(PlayerRecord.getScore());
                PlayerRecord.setPreviousScore(PlayerRecord.getScore());
            }

            if (PlayerRecord.numberOfLifes == PlayerRecord.previousNumberOfLifes - 1)
            {
                heartManager.removeOneHeart(PlayerRecord.numberOfLifes);
                PlayerRecord.previousNumberOfLifes = PlayerRecord.numberOfLifes;
            }
            else if (PlayerRecord.numberOfLifes != PlayerRecord.previousNumberOfLifes)
            {
                heartManager.changeVisibleHeartsNumber(PlayerRecord.numberOfLifes);
                PlayerRecord.previousNumberOfLifes = PlayerRecord.numberOfLifes;
            }

            if (PlayerRecord.health <= 0)
            {

                PlayerRecord.numberOfLifes--;
                if (PlayerRecord.numberOfLifes > 0)
                {
                    PlayerRecord.health = PlayerRecord.maxHealth;
                }
                else
                {
                    animator.SetBool("isDead", true);
                    heartManager.changeVisibleHeartsNumber(0);
                    PlayerRecord.previousNumberOfLifes = PlayerRecord.numberOfLifes;

                    waitingForDeath = true;
                    StartCoroutine(waitForDeath(5));
                }
            }

        }
    }

    IEnumerator waitForDeath(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log("Death of player");
        Application.Quit();
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

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Ground") && Mathf.Abs(rb.velocity.y) < 0.1
            && collision2D.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Ground") && Mathf.Abs(rb.velocity.y) < 0.1 
            && collision2D.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Ground"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

}