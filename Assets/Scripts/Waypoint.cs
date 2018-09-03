using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [Header("Assignments")]
    public GameObject hero;
	public GameObject[] waypoints = new GameObject[3];
    public int currentWaypoint;

    public int rotate;

    public int speed;
    
	void Start ()
    {
		currentWaypoint = 0;
	}
	
	void Update ()
    {
		hero.transform.position = Vector3.MoveTowards (hero.transform.position, 
		waypoints[currentWaypoint].transform.position, speed * Time.deltaTime);

		if (currentWaypoint < waypoints.Length) {

			if (Vector3.Distance (hero.transform.position, waypoints [currentWaypoint].transform.position) < 0.1f)
			{
				currentWaypoint++;
                transform.Rotate(0, 0, rotate);
			}

		}

        if (currentWaypoint == 4)
        {
            currentWaypoint = 0;
        }
		
	}

}
