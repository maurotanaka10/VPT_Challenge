using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timerToDelivery;
    private bool timerIsRunning = false;
    private float currentTime;
    [SerializeField] private GameObject penaltyText;
    [SerializeField] private float penaltyTime;

    public bool gameIsOver;


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
        currentTime = timerToDelivery;
        timerText.text = timerToDelivery.ToString("0");
    }

    public void Penalty()
    {
        currentTime -= penaltyTime;
    }
}
