using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [HideInInspector]
    public int difficulty;
    float playTime;
    float raiseTime = 10f;

    void FixedUpdate()
    {
        playTime += Time.deltaTime;

        if (playTime >= raiseTime)
        {
            playTime = 0f;
            difficulty++;
        }   
    }
}
