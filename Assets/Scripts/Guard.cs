using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour {

    [Header("States/Stats")]
    public bool alert = false;
    public bool spottedPlayer = false;
    public float speed;

    [Header("Transforms")]
    public GameObject playerLocation;

    [Header("Raycast")]
    public Transform sightStart, sightEnd;
    public Vector3 sStart, sEnd;

    void Start ()
    {
        playerLocation = GameObject.Find("Player");
    }

    void Update()
    {
        RayCasting();
        RunTowardsPlayer();
    }

    void RayCasting()
    {
        sStart = sightStart.transform.position;
        sEnd = sightEnd.transform.position;
        Debug.DrawLine(sStart, sEnd, Color.green);
        spottedPlayer = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
    }

    void RunTowardsPlayer()
    {
        if (spottedPlayer)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.LookAt(playerLocation.transform.position);
            transform.Rotate(new Vector3(0, 90, 90), Space.Self);
        }
    }

}
