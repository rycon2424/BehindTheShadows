using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Header("PlayerHp")]
    public static int playerHP;
    [Header(" ")]
    public static bool Minigame = false;
    public int whatMinigame;
    public float minigameDuration;
    public GameObject mainScene;
    public GameObject mainCamera;
    public GameObject[] minigames = new GameObject[2];

    void Update()
    {
        if (Minigame)
        {
            whatMinigame = Random.Range(0, 2);
            minigames[whatMinigame].SetActive(true);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        Minigame = false;
        mainScene.SetActive(false);
        mainCamera.SetActive(false);
        if (whatMinigame == 0)
        {
            Guard_Minigame1.death = false;
        }
        yield return new WaitForSecondsRealtime(minigameDuration);
        if (whatMinigame == 1)
        {
            UnderShadowMinigame.attackCooldown = true;
        }
        if (whatMinigame == 0)
        {
            Guard_Minigame1.death = true;
        }
        minigames[whatMinigame].SetActive(false);
        mainCamera.SetActive(true);
        mainScene.SetActive(true);
    }
}