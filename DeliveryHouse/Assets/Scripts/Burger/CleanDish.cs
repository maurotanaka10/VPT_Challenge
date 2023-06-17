using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanDish : MonoBehaviour
{
    private List<GameObject> itensToDestroy = new List<GameObject>();


    public void AddItensToDestroy(GameObject itens)
    {
        itensToDestroy.Add(itens);
    }
    public void CleanDishAfterRecipe()
    {
        foreach (GameObject item in itensToDestroy)
        {
            Destroy(item);
        }

        itensToDestroy.Clear();
    }
}
