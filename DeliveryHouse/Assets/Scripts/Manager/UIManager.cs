using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float money;
    [SerializeField] private TMP_Text moneyText;

    private void Awake()
    {

    }

    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
