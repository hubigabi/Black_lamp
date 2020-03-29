using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heart : MonoBehaviour
{
    private SoundManager soundManager;

    void Start()
    {
       soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        bool result = false;
        PlayerRecord.isHeartCollectedInScene.TryGetValue(SceneManager.GetActiveScene().name, out result);
        if (result == true || (PlayerRecord.numberOfLifes == PlayerRecord.maxNumberOfLifes && PlayerRecord.health == PlayerRecord.maxHealth))
        {
            Destroy(this.gameObject);
        }
    }

        void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag.Equals("Player"))
        {
            if (PlayerRecord.numberOfLifes < PlayerRecord.maxNumberOfLifes) {
                soundManager.playSound("newLife");
                PlayerRecord.numberOfLifes++;
                Destroy(gameObject);
                PlayerRecord.isHeartCollectedInScene.Add(SceneManager.GetActiveScene().name, true);
            } else if (PlayerRecord.health < PlayerRecord.maxHealth) {
                soundManager.playSound("newLife");
                PlayerRecord.health = PlayerRecord.maxHealth;
                Destroy(gameObject);
                PlayerRecord.isHeartCollectedInScene.Add(SceneManager.GetActiveScene().name, true);
            }

        }

    }
}
