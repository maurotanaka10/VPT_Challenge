using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burger", menuName = "My Project/Burger/New Burger")]
public class BurgerScriptableObject : ScriptableObject
{
    [SerializeField] private string nameBurger;
    [SerializeField] private Sprite iconBurger;
    [SerializeField] private Ingredients ingredient01, ingredient02, ingredient03;

    public string GetBurgerName()
    {
        return nameBurger;
    }
}

public enum Ingredients
{
    Meat,
    Salad,
    Tomato,
    Onion,
    Cheese,
    Pickles
}
