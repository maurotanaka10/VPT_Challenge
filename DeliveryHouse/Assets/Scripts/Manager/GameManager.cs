using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BurgerValidate _burgerValidate;

    public bool GameIsRunning = false;
    public bool GameIsOver = false;

    private void Awake()
    {
        
    }

    public void StartGame()
    {
        _burgerValidate.FirstRequest();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
