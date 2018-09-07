using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneString : MonoBehaviour {

    public float time;
    public string sceneName;

	void Start ()
    {
        StartCoroutine(ResetGame());
    }
	
    IEnumerator ResetGame()
    {
        yield return new WaitForSecondsRealtime(time);
        GameManager.playerHP = 5;
        BloodCanvas.Blood = false;
        SceneManager.LoadScene(sceneName);
    }
}
