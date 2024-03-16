namespace CookieCookbook.Ingredients
{
    public static class IngredientValidator
    {
        public static bool Validate(string input, List<string> availableIngredients) => availableIngredients.Contains(input);
    }
}