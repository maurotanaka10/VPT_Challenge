using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _startGameTxt;
    [SerializeField] private GameObject _startGameTxt2;
    [SerializeField] private float _initialTimer;
    [SerializeField] private float _gameTimer;
    private float _timer;
    private bool _timerIsRunning = false;
    private float _currentTime;

    private void Awake()
    {
        StartGameTimer();
    }

    private void FixedUpdate()
    {
        if (_timerIsRunning)
        {
            _currentTime -= Time.deltaTime;

            string minutes = ((int)_currentTime / 60).ToString("00");
            string seconds = (_currentTime % 60).ToString("00");
            string timeText = minutes + ":" + seconds;

            if (_gameManager.GameIsRunning)
            {
                _timerText.text = timeText;

                if (_currentTime <= 0f)
                {
                    _currentTime = 0f;
                    StopTimer();
                    _gameManager.GameIsOver = true;
                    _gameManager.GameIsRunning = false;
                }
            }
            else
            {
                _startGameTxt.text = timeText;

                if(_currentTime <= 0)
                {
                    _gameManager.StartGame();
                    ResetTimer();
                    _startGameTxt2.SetActive(false);
                    _gameManager.GameIsRunning = true;
                }
            }
        }
    }
    private void StopTimer()
    {
        _timerIsRunning = false;
    }

    private void ResetTimer()
    {
        _timer = _gameTimer;
        _currentTime = _timer;
        _timerText.text = _timer.ToString("0");
    }

    private void StartGameTimer()
    {
        _timerIsRunning = true;
        _timer = _initialTimer;
        _currentTime = _timer;
        _startGameTxt.text = _timer.ToString("0");
    }
}
