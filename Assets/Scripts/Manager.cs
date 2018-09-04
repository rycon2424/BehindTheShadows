using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [HideInInspector]
    public int difficulty;
    float playTime;
    float raiseTime = 10f;

    public Player player;

    public GameObject joystick;
    public GameObject pauseScreen;
    public bool isPaused;

    void Update()
    {
        
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
}
