using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip gameOver, jump, collectLamp, explosion, hit, menuMusic, finishedGame, levelChange, newLife, death; //scoreChange
    public  AudioSource audioSrc;
    public static int number = 0;

    void Start()
    {
        number++;

        if (number > 1) {
            Destroy(this.gameObject);
            number--;
        }

        DontDestroyOnLoad(this.gameObject);
        audioSrc = GetComponent<AudioSource>();

        gameOver = Resources.Load<AudioClip>("sounds/gameOver");
        jump = Resources.Load<AudioClip>("sounds/jump");
        collectLamp = Resources.Load<AudioClip>("sounds/PremiumCurrency");
        explosion = Resources.Load<AudioClip>("sounds/fireball");
        hit = Resources.Load<AudioClip>("sounds/hit_16");
        //scoreChange = Resources.Load<AudioClip>("sounds/coin_15");
        menuMusic = Resources.Load<AudioClip>("sounds/musicBackground");
        finishedGame = Resources.Load<AudioClip>("sounds/finishedGame");
        levelChange = Resources.Load<AudioClip>("sounds/moving");
        newLife = Resources.Load<AudioClip>("sounds/PowerUp");
        death = Resources.Load<AudioClip>("sounds/death");

        audioSrc.clip = menuMusic;
        audioSrc.loop = true;
        audioSrc.Play();
    }

    public void playSound(string clip)
    {
        switch (clip)
        {
            case "game_over":
                audioSrc.PlayOneShot(gameOver);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "collect":
                audioSrc.PlayOneShot(collectLamp);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosion);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "menuMusic":
                audioSrc.PlayOneShot(menuMusic);
                break;
            case "finishedGame":
                audioSrc.PlayOneShot(finishedGame);
                break;
            case "levelChange":
                audioSrc.PlayOneShot(levelChange);
                break;
            case "newLife":
                audioSrc.PlayOneShot(newLife);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;/*
            case "scoreChange":
                audioSrc.PlayOneShot(scoreChange);
                break;*/
        }
    }
}
