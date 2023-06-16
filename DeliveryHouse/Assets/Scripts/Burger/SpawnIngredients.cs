using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] private GameObject ingredient;
    [SerializeField] private Transform dishTransform;

    private void OnCollisionExit(Collision collision)
    {

        Vector3 offset = new Vector3(0f, 0.1f, 0f);

        if (collision.gameObject.tag == "BreadTop")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if(collision.gameObject.tag == "Tomato")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "Onion")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "Pickles")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "Salad")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "Meat")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "Cheese")
        {
            Instantiate(ingredient, dishTransform);
        }
        else if (collision.gameObject.tag == "BreadDown")
        {
            Instantiate(ingredient, dishTransform);
        }
    }
}
