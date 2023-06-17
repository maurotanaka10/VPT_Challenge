using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    public float Money;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private GameObject _finishHud;
    [SerializeField] private TMP_Text _finalMoneyTxt;

    private void Awake()
    {

    }

    private void Update()
    {
        _moneyText.text = Money.ToString();

        FinishGameHud();
    }

    private void FinishGameHud()
    {
        if (_gameManager.GameIsOver)
        {
            _finishHud.SetActive(true);
            _finalMoneyTxt.text = Money.ToString();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
