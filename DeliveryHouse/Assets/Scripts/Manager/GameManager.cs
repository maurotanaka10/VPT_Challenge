using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BurgerValidate burgerValidate;
    public TimerBehavior timerBehavior;
    public UIManager uIManager;

    public bool gameIsRunning = false;
    public bool gameIsOver = false;

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        burgerValidate.FirstRequest();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
