using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private SoundManager soundManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        /*
        //Camera
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        Bounds bounds = new Bounds(Camera.main.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        leftCameraBorder = bounds.center.x - bounds.extents.x;
        rightCameraBorder = bounds.center.x + bounds.extents.x;
        Debug.Log("Bounds: " + bounds);
        Debug.Log("Left camera border:" + leftCameraBorder);
        Debug.Log("Right camera border:" + rightCameraBorder);*/

        scoreToDisplay.setScoreText(PlayerRecord.getScore());
        PlayerRecord.setPreviousScore(PlayerRecord.getScore());

        healthBar.SetMaxHealth(PlayerRecord.maxHealth);
        healthBar.SetHealth(PlayerRecord.health);
        PlayerRecord.previousHealth = PlayerRecord.health;

        heartManager.changeVisibleHeartsNumber(PlayerRecord.numberOfLifes);
        PlayerRecord.previousNumberOfLifes = PlayerRecord.numberOfLifes;
        /*
        height = GameObject.Find("Player").GetComponent<Player>().GetComponent<SpriteRenderer>().bounds.size.y;
        width = GameObject.Find("Player").GetComponent<Player>().GetComponent<SpriteRenderer>().bounds.size.x;*/

        //Free rotatation along Z-axis
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

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
                soundManager.playSound("jump");
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

                soundManager.playSound("explosion");
            }
            else
            {
                animator.SetBool("isShooting", false);
            }


            /*
            if (transform.position.x < leftCameraBorder)
            {
                transform.position = new Vector3(leftCameraBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightCameraBorder)
            {
                transform.position = new Vector3(rightCameraBorder, transform.position.y, transform.position.z);
            }*/

            if (PlayerRecord.health != PlayerRecord.previousHealth)
            {
                if (PlayerRecord.health < PlayerRecord.previousHealth
                    && PlayerRecord.numberOfLifes == PlayerRecord.previousNumberOfLifes)
                {
                    soundManager.playSound("hit");
                }

                healthBar.SetHealth(PlayerRecord.health);
                PlayerRecord.previousHealth = PlayerRecord.health;

            }

            if (PlayerRecord.getScore() != PlayerRecord.getPreviousScore())
            {
                scoreToDisplay.setScoreText(PlayerRecord.getScore());
                PlayerRecord.setPreviousScore(PlayerRecord.getScore());
                //soundManager.playSound("scoreChange");
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
        soundManager.playSound("death");
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Debug.Log("Death of player");

        soundManager.playSound("game_over");
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
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
        if (collision2D.gameObject.tag.Equals("Ground") 
            && Mathf.Abs(rb.velocity.y) < 0.1
            && collision2D.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag.Equals("Ground") 
            && Mathf.Abs(rb.velocity.y) < 0.1
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking the chest:
        if (collision.gameObject.name.Equals("Chest"))
        {
            int lastLampLevel = DataManager.GetLastLampLevel();
            DataManager.SetLampLevel(lastLampLevel, true);
            LevelsManager.DisplayLamps();

            if (DataManager.CheckAll())
            {
                soundManager.playSound("finishedGame");
                SceneManager.LoadScene("Finish", LoadSceneMode.Single);
            }
            else if (lastLampLevel != 0)
            {
                soundManager.playSound("collect");
            }
            DataManager.SetLastLampLevel(0);
        }

        //Checking the lamps:
        else if (collision.gameObject.tag.Equals("Lamp"))
        {
            soundManager.playSound("collect");
            if (collision.gameObject.name.Equals("LampLevel2"))
            {
                DataManager.SetLastLampLevel(2);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel3"))
            {
                DataManager.SetLastLampLevel(3);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel4"))
            {
                DataManager.SetLastLampLevel(4);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel5"))
            {
                DataManager.SetLastLampLevel(5);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel6"))
            {
                DataManager.SetLastLampLevel(6);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel8"))
            {
                DataManager.SetLastLampLevel(8);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel9"))
            {
                DataManager.SetLastLampLevel(9);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel10"))
            {
                DataManager.SetLastLampLevel(10);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel11"))
            {
                DataManager.SetLastLampLevel(11);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (collision.gameObject.name.Equals("LampLevel12"))
            {
                DataManager.SetLastLampLevel(12);
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }

        //Corridor & Magazine travel:
        else if (collision.gameObject.tag.Equals("Door"))
        {
            if (collision.gameObject.name.Equals("ToCorridor"))
            {
                soundManager.playSound("jump");
                SceneManager.LoadScene("Corridor", LoadSceneMode.Single);
                DataManager.SetLastLevel(0);
            }
            else if (collision.gameObject.name.Equals("ToMagazine"))
            {
                SceneManager.LoadScene("Magazine", LoadSceneMode.Single);
            }

            //Level1 & Level2 travel:
            else if (collision.gameObject.name.Equals("MainToLevel1"))
            {
                GameObject.Find("MainDoor1").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(1);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level1ToMain"))
            {
                GameObject.Find("Door1").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(1);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);

            }
            else if (collision.gameObject.name.Equals("Level1ToLevel2"))
            {
                GameObject.Find("Door2").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level2", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level2ToLevel1"))
            {
                GameObject.Find("Door2").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(2);
                SceneManager.LoadScene("Level1", LoadSceneMode.Single);
            }

            //Level3 & Level4 travel:
            else if (collision.gameObject.name.Equals("MainToLevel3"))
            {
                GameObject.Find("MainDoor3").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(3);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level3ToMain"))
            {
                GameObject.Find("Door3").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(3);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level3ToLevel4"))
            {
                GameObject.Find("Door4").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level4", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level4ToLevel3"))
            {
                GameObject.Find("Door4").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(4);
                SceneManager.LoadScene("Level3", LoadSceneMode.Single);
            }

            //Level5 & Level6 travel:
            else if (collision.gameObject.name.Equals("MainToLevel5"))
            {
                GameObject.Find("MainDoor5").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(5);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level5ToMain"))
            {
                GameObject.Find("Door5").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(5);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level5ToLevel6"))
            {
                GameObject.Find("Door6").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level6", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level6ToLevel5"))
            {
                GameObject.Find("Door6").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(6);
                SceneManager.LoadScene("Level5", LoadSceneMode.Single);
            }

            //Level7 & Level8 travel:
            else if (collision.gameObject.name.Equals("MainToLevel7"))
            {
                GameObject.Find("MainDoor7").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(7);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level7ToMain"))
            {
                GameObject.Find("Door7").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(7);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level7ToLevel8"))
            {
                GameObject.Find("Door8").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level8", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level8ToLevel7"))
            {
                GameObject.Find("Door8").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(8);
                SceneManager.LoadScene("Level7", LoadSceneMode.Single);
            }

            //Level9 & Level10 travel:
            else if (collision.gameObject.name.Equals("MainToLevel9"))
            {
                GameObject.Find("MainDoor9").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(9);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level9ToMain"))
            {
                GameObject.Find("Door9").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(9);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level9ToLevel10"))
            {
                GameObject.Find("Door10").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level10", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level10ToLevel9"))
            {
                GameObject.Find("Door10").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(10);
                SceneManager.LoadScene("Level9", LoadSceneMode.Single);
            }

            //Level11 & Level12 travel:
            else if (collision.gameObject.name.Equals("MainToLevel11"))
            {
                GameObject.Find("MainDoor11").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(0);
                DataManager.SetNewLevel(11);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level11ToMain"))
            {
                GameObject.Find("Door11").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(11);
                DataManager.SetNewLevel(0);
                SceneManager.LoadScene("Gap", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level11ToLevel12"))
            {
                GameObject.Find("Door12").GetComponent<Door>().timeToOpenDoor = 0;
                SceneManager.LoadScene("Level12", LoadSceneMode.Single);
            }
            else if (collision.gameObject.name.Equals("Level12ToLevel11"))
            {
                GameObject.Find("Door12").GetComponent<Door>().timeToOpenDoor = 0;
                DataManager.SetLastLevel(12);
                SceneManager.LoadScene("Level11", LoadSceneMode.Single);
            }
        }
    }
}