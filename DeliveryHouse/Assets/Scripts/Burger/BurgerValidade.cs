using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerValidade : MonoBehaviour
{
    public AllBurger allBurger;

    public BurgerScriptableObject burgerSelected;

    private void Start()
    {
        RandomizeBurger();
        Debug.Log(burgerSelected.GetBurgerName());
    }

    public void RandomizeBurger()
    {
        burgerSelected = allBurger.GetRandomBurger();
    }
}
