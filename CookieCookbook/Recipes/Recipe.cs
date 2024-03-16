using CookieCookbook.Ingredients;
using CookieCookbook.Ingredients.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CookieCookbook.Recipes
{
    public class Recipe
    {
        private List<IIngredient> _ingredients { get; set; } = new List<IIngredient>();

        public IIngredient Addingredient(string ingredientId, Dictionary<string, IIngredient> availableIngredients)
        {
            var isValidIngredient = IngredientValidator.Validate(ingredientId, availableIngredients.Keys.ToList());
            if (!isValidIngredient)
                return null;

            IIngredient ingredient = availableIngredients[ingredientId];

            _ingredients.Add(ingredient);

            return ingredient;
        }

        public List<IIngredient> Getingredients()
        {
            return _ingredients;
        }

        public string GetIngredientsId()
        {
            List<string> ingredientIdList = new List<string>();

            foreach (var ingredient in _ingredients)
            {
                ingredientIdList.Add(ingredient.Id.ToString());
            }

            return string.Join(',', ingredientIdList);
        }
    }
}