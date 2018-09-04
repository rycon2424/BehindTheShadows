using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform guardPref;

    private float timer;
    private float timeToSpawn;
    private float maxSpawn = 30;

    public bool isEnded = false;
	
	void Update ()
    {
        if (maxSpawn <= 30)
        { 
            timeToSpawn = Random.Range(0.5f, 1.0f);
            timer += Time.deltaTime;
            if (timer >= timeToSpawn)
            {
                Instantiate(guardPref, new Vector3(0, 0, 0), Quaternion.identity);
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
