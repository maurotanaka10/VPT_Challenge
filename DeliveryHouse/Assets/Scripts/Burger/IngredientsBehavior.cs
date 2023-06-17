using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsBehavior : MonoBehaviour
{
    private void Update()
    {

    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Dish") 
        {
            //StartCoroutine();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Dish")
        {
            StopAllCoroutines();
        }
    }

    
}
