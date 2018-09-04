using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderShadowMinigame : MonoBehaviour {

    public bool attackCooldown = true;
    public int whatAttack;

	void Start ()
    {
		
	}
	
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
        yield return new WaitForSecondsRealtime(3f);
        whatAttack = Random.Range(1, 6);
        attackCooldown = true;
        Debug.Log("Attack");
    }

}