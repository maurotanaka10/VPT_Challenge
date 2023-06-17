using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public float money;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private GameObject finishHud;
    [SerializeField] private TMP_Text finalMoneyTxt;

    private void Awake()
    {

    }

    private void Update()
    {
        moneyText.text = money.ToString();

        FinishGameHud();
    }

    private void FinishGameHud()
    {
        if (gameManager.gameIsOver)
        {
            finishHud.SetActive(true);
            finalMoneyTxt.text = money.ToString();
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
