using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerValidate : MonoBehaviour
{
    public AllBurger allBurger;
    public UIManager uIManager;
    [SerializeField] private RecipeImages recipeImages;

    public BurgerScriptableObject burgerSelected;

    private List<GameObject> ingredientsOnPlate = new List<GameObject>();

    private void Awake()
    {

        RandomizeBurger();
        Debug.Log(burgerSelected.GetBurgerName());
        Debug.Log(burgerSelected.ingredient01 + "" + burgerSelected.ingredient02 + "" + burgerSelected.ingredient03 + "" + burgerSelected.ingredient04 + "" + burgerSelected.ingredient05);
    }

    public void RandomizeBurger()
    {
        burgerSelected = allBurger.GetRandomBurger();
    }

    public void AddIngredientsToPlate(GameObject ingredients)
    {
        ingredientsOnPlate.Add(ingredients);
        CheckBurgerCompletion();
    }

    private void CheckBurgerCompletion()
    {
        if(ingredientsOnPlate.Count == burgerSelected.GetBurgerIngredients().Length)
        {
            bool isComplete = true;

            foreach (GameObject ingredient in ingredientsOnPlate)
            {
                if (!IsIngredientInBurguer(ingredient))
                {
                    isComplete = false;
                    break;
                }
            }
            if (isComplete)
            {
                Debug.Log("burger feito");
                ConclusionRequest();
            }
        }
    }

    private bool IsIngredientInBurguer(GameObject ingredient)
    {
        Ingredients[] burgerIngredients = burgerSelected.GetBurgerIngredients();

        foreach (Ingredients ingredientType in burgerIngredients)
        {
            if (ingredient.CompareTag(ingredientType.ToString()))
            {
                return true;
            }
        }
        Debug.Log("Ingrediente Errado");
        WrongRequest();
        return false;
    }

    private void FirstRequest()
    {
        RandomizeBurger();
    }

    private void ConclusionRequest()
    {
        uIManager.money += burgerSelected.payment;

        foreach (GameObject ingredients in ingredientsOnPlate)
        {
            Destroy(ingredients);
        }

        RandomizeBurger();
        recipeImages.UpdateIngredientImage();
    }

    private void WrongRequest()
    {
        foreach (GameObject ingredients in ingredientsOnPlate)
        {
            Destroy(ingredients);
        }
    }
}

