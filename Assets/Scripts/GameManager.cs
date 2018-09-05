using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool Minigame = false;
    public int whatMinigame;
    public float minigameDuration;

    public GameObject mainScene;
    public GameObject[] minigames = new GameObject[2];

    void Update()
    {
        if (Minigame)
        {
            //whatMinigame = Random.Range(1, 3);
            whatMinigame = 1;
            minigames[whatMinigame].SetActive(true);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        mainScene.SetActive(false);
        yield return new WaitForSecondsRealtime(minigameDuration);
        minigames[whatMinigame].SetActive(false);
        Minigame = false;
        mainScene.SetActive(true);
    }
}