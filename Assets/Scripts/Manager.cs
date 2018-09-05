using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //Declare variables
    public enum GameType { Normal, Minigame1 };
    public GameType type;

    [HideInInspector]
    public int difficulty;
    float playTime;
    float raiseTime = 10f;

    public Player player;

    public GameObject joystick;
    public GameObject pauseScreen;
    public GameObject panel;

    public bool isPaused;

    public Spawn spawn;
    public GameObject spawner;


    void Update()
    {
        if (type == GameType.Minigame1)
        {
            //Spawner enabled
            spawner.SetActive(true);
        }
        else
        {
            //Spawner disabled
            spawner.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        playTime += Time.deltaTime;

        if (playTime >= raiseTime)
        {
            playTime = 0f;
            difficulty++;
        }
    }

    // * BUTTONS * \\ 
    public void Use()
    {
        if (player.canUse)
        {
            //Type here what to do
            Debug.Log("Use");
        }
    }

    public void Peek()
    {
        if (player.canPeek)
        {
            //Type here what to do
            Debug.Log("Peek");
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 1;
            isPaused = true;
            pauseScreen.SetActive(false);
            joystick.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = false;
            pauseScreen.SetActive(true);
            joystick.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
    }

    public void Exit()
    {
        pauseScreen.SetActive(false);
        panel.SetActive(true);
    }

    public void ExitYes()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitNo()
    {
        panel.SetActive(false);
        pauseScreen.SetActive(true);
    }
}

