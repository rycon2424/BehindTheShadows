using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public GameObject laser;
    public float time;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(time);
        laser.SetActive(true);
    }
}
