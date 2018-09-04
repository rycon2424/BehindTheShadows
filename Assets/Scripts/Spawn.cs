using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform guardPref;

    private float timer;
    private float timeToSpawn;
    private float maxSpawn = 30;
    private float randomX;
    private float randomY;

    public bool isEnded = false;
	
	void Update ()
    {
        if (maxSpawn <= 30)
        { 
            timeToSpawn = Random.Range(0.5f, 1.0f);
            timer += Time.deltaTime;
            if (timer >= timeToSpawn)
            {
                randomX = Random.Range(-8, 8);
                randomY = Random.Range(1, 4);
                Instantiate(guardPref, new Vector3(randomX, randomY, 0), Quaternion.identity);
                timer = 0;
                timeToSpawn = Random.Range(0.5f, 1.0f);
            }
        }
        else
        {
            isEnded = true;
        }
	}
}
