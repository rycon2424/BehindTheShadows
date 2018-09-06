using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard_Minigame1 : MonoBehaviour
{
    //Declare variables
    public GameObject player;
    public int speed;
    public static bool death = false;

	void Start ()
    {
        //Find player
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(2, 7);
	}
	
	void Update ()
    {
        //Follow player
        transform.LookAt(player.transform.position);
        transform.Rotate(90, 0, 0);
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        //Destroy Guard by leaving minigame
        if(death == true)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //When collides with player
        if (col.gameObject.tag == "Player")
        {
            if (GameManager.canTakeDamage)
            {
                GameManager.playerHP = GameManager.playerHP - 1;
                GameManager.canTakeDamage = false;
            }
            Debug.Log("Leven kwijt");
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }
}
