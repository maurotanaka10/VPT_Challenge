using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "All Burgers", menuName = "My Project/Burger/All Burgers")]
public class AllBurger : ScriptableObject
{
    [SerializeField] private BurgerScriptableObject[] burgerGroup = new BurgerScriptableObject[] { };
    private bool optimized = false;
    private Dictionary<string, BurgerScriptableObject> optimizedBurgers = new Dictionary<string, BurgerScriptableObject>();

    public bool ContainsBurger(string burgerName)
    {
        if (!optimized)
            Optimize();

        return optimizedBurgers.ContainsKey(burgerName.ToLower());
    }
    public BurgerScriptableObject GetBurger(string burgerName)
    {
        if (!optimized)
            Optimize();

        return optimizedBurgers[burgerName.ToLower()];
    }

    private void Optimize()
    {
        optimizedBurgers.Clear();
        foreach (BurgerScriptableObject burger in burgerGroup)
        {
            string burgerName = burger.name;//nome do editor
            burgerName = burgerName.ToLower();
            optimizedBurgers.Add(burgerName, burger);
        }
    }

    public BurgerScriptableObject GetRandomBurger()
    {
        if (!optimized)
            Optimize();

        int randomBurger = Random.Range(0, optimizedBurgers.Count);

        string randomBurgerName = optimizedBurgers.Keys.ElementAt(randomBurger);

        return GetBurger(randomBurgerName);
    }
}
