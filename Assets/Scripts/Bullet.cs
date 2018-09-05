using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Guard")
        {
            Debug.Log("hit");
            Destroy(col.gameObject);
        }
    }
}