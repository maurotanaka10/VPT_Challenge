using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "All Burgers", menuName = "My Project/Burger/All Burgers")]
public class AllBurger : ScriptableObject
{
    [SerializeField] private BurgerScriptableObject[] _burgerGroup = new BurgerScriptableObject[] { };
    private bool _optimized = false;
    private Dictionary<string, BurgerScriptableObject> _optimizedBurgers = new Dictionary<string, BurgerScriptableObject>();

    public bool ContainsBurger(string burgerName)
    {
        if (!_optimized)
            Optimize();

        return _optimizedBurgers.ContainsKey(burgerName.ToLower());
    }
    public BurgerScriptableObject GetBurger(string burgerName)
    {
        if (!_optimized)
            Optimize();

        return _optimizedBurgers[burgerName.ToLower()];
    }

    private void Optimize()
    {
        _optimizedBurgers.Clear();
        foreach (BurgerScriptableObject burger in _burgerGroup)
        {
            string burgerName = burger.name;//nome do editor
            burgerName = burgerName.ToLower();
            _optimizedBurgers.Add(burgerName, burger);
        }
    }

    public BurgerScriptableObject GetRandomBurger()
    {
        if (!_optimized)
            Optimize();

        int randomBurger = Random.Range(0, _optimizedBurgers.Count);

        string randomBurgerName = _optimizedBurgers.Keys.ElementAt(randomBurger);

        return GetBurger(randomBurgerName);
    }
}
