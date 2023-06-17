using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Burger", menuName = "My Project/Burger/New Burger")]
public class BurgerScriptableObject : ScriptableObject
{
    [SerializeField] private string nameBurger;
    [SerializeField] private Sprite iconBurger;
    public Ingredients ingredient01, ingredient02, ingredient03, ingredient04, ingredient05;
    public float payment;

    public string GetBurgerName()
    {
        return nameBurger;
    }

    public Ingredients[] GetBurgerIngredients()
    {
        return new Ingredients[] { ingredient01, ingredient02, ingredient03, ingredient04, ingredient05 };
    }
}

public enum Ingredients
{
    Null,
    Meat,
    Salad,
    Tomato,
    Onion,
    Cheese,
    Pickles,
    BreadTop,
    BreadDown
}
