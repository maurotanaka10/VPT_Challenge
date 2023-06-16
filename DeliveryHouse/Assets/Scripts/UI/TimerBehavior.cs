using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timer;
    private bool timerIsRunning = false;
    private float currentTime;

    private void Awake()
    {
        ResetTimer();
        StartTimer();
    }

    private void FixedUpdate()
    {
        if (timerIsRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                StopTimer();
            }

            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");
            string timeText = minutes + ":" + seconds;
            timerText.text = timeText;
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = timer;
        timerText.text = timer.ToString("0");
    }
}
