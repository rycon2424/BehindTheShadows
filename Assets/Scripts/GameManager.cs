using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    [Header("PlayerHp")]
    public Text hpText;
    public static int playerHP = 5;
    public static bool canTakeDamage = true;
    [Header(" ")]
    public static bool Minigame = false;
    public int whatMinigame;
    public float minigameDuration;
    public GameObject mainScene;
    public GameObject mainCamera;
    public GameObject youLostCanvas;
    public GameObject[] minigames = new GameObject[2];
    
    private void Start()
    {
        youLostCanvas.SetActive(false);
        hpText.text = playerHP.ToString();
    }
    void Update()
    {
        if (Minigame)
        {
            whatMinigame = Random.Range(0, 2);
            minigames[whatMinigame].SetActive(true);
            StartCoroutine(Timer());
        }
        if (!Minigame)
        {
            if (playerHP == 0)
            {
                youLostCanvas.SetActive(true);
            }
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
        hpText.text = playerHP.ToString();
        minigames[whatMinigame].SetActive(false);
        mainCamera.SetActive(true);
        mainScene.SetActive(true);
        canTakeDamage = true;
    }
}