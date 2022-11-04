using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private TMP_Text healthDisplay;
    [SerializeField] private TMP_Text scoreDisplay;

    [SerializeField] private GameObject startButtons;
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject winScreen;

    LevelManager levelManager;


    private void Start()
    {
        Time.timeScale = 0f;
        startButtons.SetActive(true);
        pause.SetActive(false);
        winScreen.SetActive(false);
        levelManager = FindObjectOfType<LevelManager>();
    }
    public void ChangeHealthDisplay(int health)
    {
        healthDisplay.text = "Health: " + health;
    }


    public void OnStartButtonDown()
    {
        startButtons.SetActive(false);
        Time.timeScale = 1f;
        pause.SetActive(true);
    }

    public void OnPauseButtonDown()
    {
        Time.timeScale = 0f;
        startButtons.SetActive(true);
    }

    public void OnNextLevelButtonDown()
    { 
    levelManager.NextLevel();
    }

    public void OnRestartButtonDown()
    { 
    levelManager.ReloadScene();
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}
