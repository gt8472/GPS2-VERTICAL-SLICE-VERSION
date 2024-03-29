﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject LoseUI;
    public GameObject WinUI;
    public GameObject ShopUI;
    public GameObject JoyUI;

    public static GameManager Instance;
    private EnemySpawner EnemySpawner;
    void Awake()
    {
        Instance = this;
        EnemySpawner = GetComponent<EnemySpawner>();
        LoseUI.SetActive(false);
        WinUI.SetActive(false);

    }

    public void Win()
    {
        Time.timeScale = 0;
        WinUI.SetActive(true);
        ShopUI.SetActive(false);
        JoyUI.SetActive(false);
        SoundManager.PlaySound("Win1");
    }

    private void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            Failed();
        }
    }

    public void Failed()
    {

        LoseUI.SetActive(true);
        ShopUI.SetActive(false);
        JoyUI.SetActive(false);
        Time.timeScale = 0;
        //EnemySpawner.Stop();
    }

    public void OnButtonRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LoseUI.SetActive(false);
        ShopUI.SetActive(true);
        JoyUI.SetActive(true);
        EnemySpawner.WaitPlayer();
    }

    public void OnButtonMenu()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnButtonNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
