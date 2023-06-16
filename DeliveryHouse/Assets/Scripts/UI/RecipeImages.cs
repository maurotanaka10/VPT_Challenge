using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeImages : MonoBehaviour
{
    public AllBurger allBurger;
    private RecipeImages _recipeImage;
    [SerializeField] private BurgerValidate burgerValidate;


    public Image[] ingredientRecipe;
    public Sprite spriteMeat, spriteBreadUp, spriteBreadDown, spriteTomato, spriteOnion, spritePickles, spriteCheese, spriteLettuce;

    private Dictionary<Ingredients, Sprite> ingredientSprites = new Dictionary<Ingredients, Sprite>();

    public void Initialize(RecipeImages recipeImages)
    {
        _recipeImage = recipeImages;
    }

    private void Start()
    {
        ingredientSprites.Add(Ingredients.Meat, spriteMeat);
        ingredientSprites.Add(Ingredients.BreadDown, spriteBreadDown);
        ingredientSprites.Add(Ingredients.BreadTop, spriteBreadUp);
        ingredientSprites.Add(Ingredients.Tomato, spriteTomato);
        ingredientSprites.Add(Ingredients.Onion, spriteOnion);
        ingredientSprites.Add(Ingredients.Salad, spriteLettuce);
        ingredientSprites.Add(Ingredients.Pickles, spritePickles);
        ingredientSprites.Add(Ingredients.Cheese, spriteCheese);

        UpdateIngredientImage();
    }

    public void UpdateIngredientImage()
    {
        Ingredients[] ingredients = burgerValidate.burgerSelected.GetBurgerIngredients();

        if(ingredients.Length > 0)
        {
            ingredientRecipe[0].sprite = ingredientSprites[ingredients[0]];
            ingredientRecipe[1].sprite = ingredientSprites[ingredients[1]];
            ingredientRecipe[2].sprite = ingredientSprites[ingredients[2]];
            ingredientRecipe[3].sprite = ingredientSprites[ingredients[3]];
            ingredientRecipe[4].sprite = ingredientSprites[ingredients[4]];
        }
    }
}
