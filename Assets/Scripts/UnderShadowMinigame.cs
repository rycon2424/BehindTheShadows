using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderShadowMinigame : MonoBehaviour {

    public bool attackCooldown = true;
    public int whatAttack;

    [Header("Attacks")]
    public GameObject[] Lasers = new GameObject[3];

	void Update ()
    {
        if (attackCooldown)
        {
            attackCooldown = false;
            StartCoroutine(Cooldown());
        }
	}

    IEnumerator Cooldown()
    {
        yield return new WaitForSecondsRealtime(2f);
        whatAttack = Random.Range(1, 4);
        if (whatAttack == 1)
        {
            Instantiate(Lasers[0], Lasers[0].transform.position, Lasers[0].transform.rotation);
        }
        if (whatAttack == 2)
        {
            Instantiate(Lasers[1], Lasers[1].transform.position, Lasers[1].transform.rotation);
        }
        if (whatAttack == 3)
        {
            Instantiate(Lasers[2], Lasers[2].transform.position, Lasers[2].transform.rotation);
        }
        yield return new WaitForSecondsRealtime(2f);
        attackCooldown = true;
    }
        
}