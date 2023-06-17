using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerValidate : MonoBehaviour
{
    public AllBurger allBurger;
    public UIManager uIManager;
    public AudioController audioController;
    public CleanDish cleanDish;
    [SerializeField] private RecipeImages recipeImages;

    [SerializeField] private float lostMoney;

    public BurgerScriptableObject burgerSelected;

    public List<GameObject> ingredientsOnPlate = new List<GameObject>();

    private void Awake()
    {
        
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
        if (ingredientsOnPlate.Count == burgerSelected.GetBurgerIngredients().Length)
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

    public void FirstRequest()
    {
        RandomizeBurger();
        recipeImages.UpdateIngredientImage();
    }

    private void ConclusionRequest()
    {
        uIManager.money += burgerSelected.payment;
        ingredientsOnPlate.Clear();
        cleanDish.CleanDishAfterRecipe();
        audioController.CorrectRecipeSound();

        RandomizeBurger();
        recipeImages.UpdateIngredientImage();
    }

    private void WrongRequest()
    {
        uIManager.money -= lostMoney;
        cleanDish.CleanDishAfterRecipe();
        audioController.WrongRecipeSound();

        ingredientsOnPlate.Clear();
    }
}

