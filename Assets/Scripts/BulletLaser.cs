using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaser : MonoBehaviour
{
    public int speed;
    public bool start = false;
    public GameObject Laser;

    void Start()
    {
        StartCoroutine(Cooldown());
    }

    void Update()
    {
        if (start)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(2f);
        start = true;
        Destroy(Laser.gameObject);
        yield return new WaitForSecondsRealtime(3f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
        }
    }
}
