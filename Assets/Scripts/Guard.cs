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

    [Header("Spots")]
    public bool spottedPlayer = false;

    [Header("RayCasts")]
    Ray myRay;
    RaycastHit hit;
    public GameObject playerLocation;

    [Header("Alert")]
    public float rotateSpeed;
    public float time;
    bool startTimer = true;      //alertTimer
    bool canRotate = true;       //If the guard can rotate

    void Start()
    {
        playerLocation = GameObject.Find("Player");
    }

    void Update()
    {
        RayCast();
        Alert();
        if (standing && !alert)
        {
            StandingGuard();
        }
    }

    #region methods

    void RayCast()
    {
        myRay = new Ray(transform.position, transform.up);
        Debug.DrawRay(transform.position, transform.up * 30f);

        if (Physics.Raycast(myRay, out hit, 30f))
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

    #endregion

    #region IEnums

    IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(time);
        rotateSpeed = rotateSpeed * -1;
        startTimer = true;
    }

    IEnumerator AlertTimer()
    {
        yield return new WaitForSecondsRealtime(10);
        if (alert)
        {
            StopCoroutine(AlertTimer());
        }
        alert = false;
    }
    
    IEnumerator Rotate()
    {
        yield return new WaitForSecondsRealtime(0.9f);
        canRotate = false;
        yield return new WaitForSecondsRealtime(0.9f);
        canRotate = true;
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Gameobject.SetActive(false);
            Debug.Log("Start Minigame");
            //Gameobject.SetActive(true);
            Debug.Log("Disable alle gameobjects");
            Destroy(this.gameObject);
        }
    }
}
