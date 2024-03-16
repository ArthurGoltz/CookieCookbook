using CookieCookbook.Recipes;
using System.Text.Json;

namespace CookieCookbook.Cookbook
{
    public class CookbookTxt : Cookbook, ICookbookType
    {
        public CookbookTxt(string fileName) : base(fileName)
        {
        }

        public override List<Recipe> ReadCookbook()
        {
            var cookbook = OpenCookbook();
            if (cookbook is null) new List<Recipe>();

            List<string> recipesIDs = new List<string>();

            using (var reader = new StreamReader(cookbook))
            {
                while (!reader.EndOfStream)
                {
                    recipesIDs.Add(reader.ReadLine());
                }
            }

            return ListRecipes(recipesIDs);
        }

        public override Recipe WriteCookbook(List<Recipe> existingRecipes)
        {
            var currentRecipe = CreateRecipe();

            if (currentRecipe.Getingredients().Count <= 0)
                return null;

            existingRecipes.Add(currentRecipe);

            List<string> recipesList = new List<string>();
            foreach (var recipe in existingRecipes)
            {
                recipesList.Add(recipe.GetIngredientsId());
            }

            var cookbook = CreateCookbook();
            if (cookbook == null) return null;

            using (var writer = new StreamWriter(cookbook))
            {
                cookbook.Position = 0;
                writer.Write(JsonSerializer.Serialize(recipesList));
                writer.Flush();

                cookbook.SetLength(cookbook.Position);
            }

            return currentRecipe;
        }

    }
}
