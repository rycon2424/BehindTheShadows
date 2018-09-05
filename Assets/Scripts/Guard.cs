using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{

    [Header("States/Stats")]
    public bool standing;       //if this guard is standing
    public bool walking;        //if this guard is walking
    [Header(" ")]
    public bool alert = false;  //Alert Phase check
    public float speed;         //Running speed towards player
    public float rotateSpeedCalm;   //RotationSpeed when standing still (No Alarm)

    [Header("Waypoints")]
    GameObject currentGuard;
    public GameObject[] waypoints = new GameObject[3];
    public int currentWaypoint;
    public int rotateOnWaypoint;    //How much the guard rotates(z) when reaching a waypoint
    public int speedWalk;           //Normal walking speed

    [Header(" ")]
    public bool spottedPlayer = false;

    [Header("RayCasts")]
    Ray myRay;
    RaycastHit hit;
    public GameObject playerLocation;
    public float raycastRange;

    [Header("Alert")]
    public float rotateSpeed;
    public float time;
    bool startTimer = true;      //alertTimer
    bool canRotate = true;       //If the guard can rotate

    [Header(" ")]
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentGuard = this.gameObject;
        playerLocation = GameObject.Find("Player");
        if (walking)
        {
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        RayCast();
        Alert();
        if (walking && !alert)
        {
            anim.SetInteger("State", 0);
            WalkingSystem();
        }
        if (standing && !alert)
        {
            anim.SetInteger("State", 1);
            StandingGuard();
        }
        if (alert)
        {
            anim.SetInteger("State", 1);
        }
    }

    #region methods

    void RayCast()
    {
        myRay = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * raycastRange);

        if (Physics.Raycast(myRay, out hit, raycastRange))
        {
            if (hit.collider.tag == "Player")
            {
                StartCoroutine(AlertTimer());
                spottedPlayer = true;
            }
            if (hit.collider.tag == "Player" == false)
            {
                spottedPlayer = false;
            }
        }
    }

    void Alert()
    {
        if (spottedPlayer)
        {
            alert = true;
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.LookAt(playerLocation.transform.position);
            transform.Rotate(new Vector3(0, 90, 90), Space.Self);
        }
        if (!spottedPlayer && alert)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed));
            if (startTimer)
            {
                StartCoroutine(Timer());
                startTimer = false;
            }
        }
    }

    void StandingGuard()
    {
        if (canRotate && !alert)
        {
            StartCoroutine(Rotate());
            transform.Rotate(new Vector3(0, 0, rotateSpeedCalm));
        }
    }

    void WalkingSystem()
    {
        currentGuard.transform.position = Vector3.MoveTowards(currentGuard.transform.position,
        waypoints[currentWaypoint].transform.position, speedWalk * Time.deltaTime);

        if (currentWaypoint < waypoints.Length)
        {
            if (Vector3.Distance(currentGuard.transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)
            {
                currentWaypoint++;
                transform.Rotate(0, 0, rotateOnWaypoint);
            }
        }
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }

    }

    #endregion

    #region IEnums

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        rotateSpeed = rotateSpeed * -1;
        startTimer = true;
    }

    IEnumerator AlertTimer()
    {
        yield return new WaitForSeconds(10);
        if (alert)
        {
            StopCoroutine(AlertTimer());
        }
        alert = false;
    }
    
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(0.9f);
        canRotate = false;
        yield return new WaitForSeconds(0.9f);
        canRotate = true;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Minigame = true;
            Destroy(this.gameObject);
        }
    }
}