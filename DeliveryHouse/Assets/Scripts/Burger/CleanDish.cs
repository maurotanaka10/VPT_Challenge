using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDish : MonoBehaviour
{
    private List<GameObject> _itensToDestroy = new List<GameObject>();


    public void AddItensToDestroy(GameObject itens)
    {
        _itensToDestroy.Add(itens);
    }
    public void CleanDishAfterRecipe()
    {
        foreach (GameObject item in _itensToDestroy)
        {
            Destroy(item);
        }

        _itensToDestroy.Clear();
    }
}
