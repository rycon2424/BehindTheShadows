using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform guardPref;

    private float timer;
    private float timeToSpawn;
    private float randomX;
    private float randomZ;
	
	void Update ()
    {
        timeToSpawn = Random.Range(0.2f, 0.8f);
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            randomX = Random.Range(-10, 10);
            randomZ = Random.Range(5, 8);
            Instantiate(guardPref, new Vector3(randomX, 0, randomZ), Quaternion.identity);
            timer = 0;
            timeToSpawn = Random.Range(0.2f, 0.8f);
        }
        else
        {

        }
	}
}
