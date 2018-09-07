using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    public bool canSkip = false;

    private void Start()
    {
        StartCoroutine(ResetGame());
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0) && canSkip)
        {
            GameManager.playerHP = 5;
            SceneManager.LoadScene(0);
        }
	}

    IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(8);
        canSkip = true;

    }
}
