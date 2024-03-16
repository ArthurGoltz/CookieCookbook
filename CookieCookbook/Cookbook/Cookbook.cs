
using CookieCookbook.Ingredients.Interfaces;
using CookieCookbook.Ingredients;
using CookieCookbook.Recipes;

namespace CookieCookbook.Cookbook
{
    public abstract class Cookbook
    {
        private readonly string _fileName;

        public readonly Dictionary<string, IIngredient> AvailableIngredients = new()
        {
            {"1",new WheatFlour() },
            {"2",new CoconutFlour()},
            {"3",new Butter()},
            {"4",new Chocolate()},
            {"5",new Sugar()},
            {"6",new Cadamom()},
            {"7",new Cinnamon()},
            {"8", new CocoaPowder()}
        };

        public Cookbook(string fileName)
        {
            _fileName = fileName;
        }

        public abstract List<Recipe> ReadCookbook();

        public abstract Recipe WriteCookbook(List<Recipe> ExistingRecipes);

        protected FileStream OpenCookbook()
        {
            if (File.Exists(_fileName))
            {
                return File.OpenRead(_fileName);
            }
            return CreateCookbook();     
        }

        protected FileStream CreateCookbook()
        {
            if (!File.Exists(_fileName))
            {
                return File.Create(_fileName);
            }
            return File.OpenWrite(_fileName);
        }

        protected List<Recipe> ListRecipes(List<string> existingRecipes)
        {

            Console.WriteLine("Existing recipes are:");
            Console.WriteLine("");

            int recipesCount = 0;
            List<Recipe> recipesList = new List<Recipe>(); 
            
            foreach (var existingRecipe in existingRecipes)
            {
                var ingredientsID = existingRecipe.Split(',');
                recipesCount++;

                Console.WriteLine($"***** {recipesCount} *****");
                var availableIngredients = AvailableIngredients;

                Recipe recipe = new Recipe();

                foreach (var ingredientID in ingredientsID)
                {
                    var ingredient = recipe.Addingredient(ingredientID, availableIngredients);
                    Console.WriteLine(ingredient.DescribeInstructions());
                }
                recipesList.Add(recipe);   
            }
            return recipesList;
        }

        protected Recipe CreateRecipe()
        {
            Console.WriteLine("");
            Console.WriteLine("Create a new cookie recipe! Available ingredients are: ");
            foreach (var ingredient in AvailableIngredients.Values)
                Console.WriteLine(ingredient.ToString());

            string input;
            var recipe = new Recipe();
            do
            {
                Console.WriteLine("Add an ingredient by it's Id or type anything else if finished");
                input = Console.ReadLine().ToString();
                recipe.Addingredient(input, AvailableIngredients);

            } while (AvailableIngredients.ContainsKey(input));



            return recipe;
    }

        public void CloseCookbook(Recipe newRecipe)
        {
            if (newRecipe is not null)
            {
                Console.WriteLine("Recipe Added");
                foreach (var ingredient in newRecipe.Getingredients())
                {
                    Console.WriteLine(ingredient.DescribeInstructions());
                }
            }
            else
                Console.WriteLine("No recipe added");
        }
    }
}