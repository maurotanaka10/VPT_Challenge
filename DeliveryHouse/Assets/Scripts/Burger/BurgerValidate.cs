using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerValidate : MonoBehaviour
{
    [SerializeField] private AllBurger _allBurger;
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private AudioController _audioController;
    [SerializeField] private CleanDish _cleanDish;
    [SerializeField] private RecipeImages _recipeImages;
    [SerializeField] private DishController _dishController;

    [SerializeField] private float _lostMoney;

    public BurgerScriptableObject BurgerSelected;

    public List<GameObject> IngredientsOnPlate = new List<GameObject>();

    private void Awake()
    {
        
    }

    public void RandomizeBurger()
    {
        BurgerSelected = _allBurger.GetRandomBurger();
    }

    public void AddIngredientsToPlate(GameObject ingredients)
    {
        IngredientsOnPlate.Add(ingredients);
        CheckBurgerCompletion();
    }

    private void CheckBurgerCompletion()
    {
        if (IngredientsOnPlate.Count == BurgerSelected.GetBurgerIngredients().Length)
        {
            bool isComplete = true;
            Ingredients[] burgerIngredients = BurgerSelected.GetBurgerIngredients();

            foreach (Ingredients ingredientType in burgerIngredients)
            {
                bool foundIngredient = false;

                foreach (GameObject ingredient in IngredientsOnPlate)
                {
                    if (ingredient.CompareTag(ingredientType.ToString()))
                    {
                        foundIngredient = true;
                        break;
                    }
                }

                if (!foundIngredient)
                {
                    isComplete = false;
                    Debug.Log("Ingrediente Errado");
                    WrongRequest();
                    break;
                }
            }

            if (isComplete)
            {
                Debug.Log("Burger completo");
                ConclusionRequest();
            }
        }
    }

    private bool IsIngredientInBurguer(GameObject ingredient)
    {
        Ingredients[] burgerIngredients = BurgerSelected.GetBurgerIngredients();

        foreach (Ingredients ingredientType in burgerIngredients)
        {
            if (ingredient.CompareTag(ingredientType.ToString()))
            {
                return true;
            }
        }
        return false;
    }


    public void FirstRequest()
    {
        RandomizeBurger();
        _recipeImages.UpdateIngredientImage();
    }

    private void ConclusionRequest()
    {
        _dishController.lastItem = null;
        _uIManager.Money += BurgerSelected.payment;
        IngredientsOnPlate.Clear();
        _cleanDish.CleanDishAfterRecipe();
        _audioController.CorrectRecipeSound();

        RandomizeBurger();
        _recipeImages.UpdateIngredientImage();
    }

    private void WrongRequest()
    {
        _dishController.lastItem = null;
        _uIManager.Money -= _lostMoney;
        _cleanDish.CleanDishAfterRecipe();
        _audioController.WrongRecipeSound();

        IngredientsOnPlate.Clear();
    }
}

