using CookieCookbook.Cookbook;
using CookieCookbook.Recipes;

Cookbook cookbook = new CookbookJson("recipes.json");

var ExistingRecipes = cookbook.ReadCookbook();

Recipe newRecipe = cookbook.WriteCookbook(ExistingRecipes);

cookbook.CloseCookbook(newRecipe);
