using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeImages : MonoBehaviour
{
    [SerializeField] private AllBurger _allBurger;
    [SerializeField] private BurgerValidate _burgerValidate;
    [SerializeField] private TMP_Text _recipeNameTxt;


    [SerializeField] private Image[] _ingredientRecipe;
    [SerializeField] private Sprite _spriteMeat, _spriteBreadUp, _spriteBreadDown, _spriteTomato, _spriteOnion, _spritePickles, _spriteCheese, _spriteLettuce;

    private Dictionary<Ingredients, Sprite> _ingredientSprites = new Dictionary<Ingredients, Sprite>();


    private void Start()
    {
        _ingredientSprites.Add(Ingredients.Meat, _spriteMeat);
        _ingredientSprites.Add(Ingredients.BreadDown, _spriteBreadDown);
        _ingredientSprites.Add(Ingredients.BreadTop, _spriteBreadUp);
        _ingredientSprites.Add(Ingredients.Tomato, _spriteTomato);
        _ingredientSprites.Add(Ingredients.Onion, _spriteOnion);
        _ingredientSprites.Add(Ingredients.Salad, _spriteLettuce);
        _ingredientSprites.Add(Ingredients.Pickles, _spritePickles);
        _ingredientSprites.Add(Ingredients.Cheese, _spriteCheese);
    }

    public void UpdateIngredientImage()
    {
        Ingredients[] ingredients = _burgerValidate.BurgerSelected.GetBurgerIngredients();
        _recipeNameTxt.text = _burgerValidate.BurgerSelected.GetBurgerName().ToString();

        if(ingredients.Length > 0)
        {
            _ingredientRecipe[0].sprite = _ingredientSprites[ingredients[0]];
            _ingredientRecipe[1].sprite = _ingredientSprites[ingredients[1]];
            _ingredientRecipe[2].sprite = _ingredientSprites[ingredients[2]];
            _ingredientRecipe[3].sprite = _ingredientSprites[ingredients[3]];
            _ingredientRecipe[4].sprite = _ingredientSprites[ingredients[4]];
        }
    }
}
