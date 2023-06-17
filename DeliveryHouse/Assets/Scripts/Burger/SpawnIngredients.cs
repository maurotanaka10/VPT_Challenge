using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredients : MonoBehaviour
{
    [SerializeField] private GameObject _ingredient;
    [SerializeField] private Transform _dishTransform;

    private void OnCollisionExit(Collision collision)
    {

        Vector3 offset = new Vector3(0f, 0.1f, 0f);

        if (collision.gameObject.tag == "BreadTop")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if(collision.gameObject.tag == "Tomato")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "Onion")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "Pickles")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "Salad")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "Meat")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "Cheese")
        {
            Instantiate(_ingredient, _dishTransform);
        }
        else if (collision.gameObject.tag == "BreadDown")
        {
            Instantiate(_ingredient, _dishTransform);
        }
    }
}
