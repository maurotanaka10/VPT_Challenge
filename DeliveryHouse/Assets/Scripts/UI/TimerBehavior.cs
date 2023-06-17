using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text startGameTxt;
    [SerializeField] private GameObject startGameTxt2;
    [SerializeField] private float initialTimer;
    [SerializeField] private float gameTimer;
    private float timer;
    private bool timerIsRunning = false;
    private float currentTime;

    private void Awake()
    {
        StartTimer();
    }

    private void FixedUpdate()
    {
        if (timerIsRunning)
        {
            currentTime -= Time.deltaTime;

            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            string timeText = minutes + ":" + seconds;

            if (gameManager.gameIsRunning)
            {
                timerText.text = timeText;

                if (currentTime <= 0f)
                {
                    currentTime = 0f;
                    StopTimer();
                    gameManager.gameIsOver = true;
                    gameManager.gameIsRunning = false;
                }
            }
            else
            {
                startGameTxt.text = timeText;

                if(currentTime <= 0)
                {
                    gameManager.StartGame();
                    ResetTimer();
                    startGameTxt2.SetActive(false);
                    gameManager.gameIsRunning = true;
                }
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        StartGameTimer();
    }

    private void StopTimer()
    {
        timerIsRunning = false;
    }

    private void ResetTimer()
    {
        timer = gameTimer;
        currentTime = timer;
        timerText.text = timer.ToString("0");
    }

    private void StartGameTimer()
    {
        timer = initialTimer;
        currentTime = timer;
        startGameTxt.text = timer.ToString("0");
    }
}
