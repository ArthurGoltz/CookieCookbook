using CookieCookbook.Enums;
using CookieCookbook.Recipes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CookieCookbook.Cookbook
{
    public class CookbookJson : Cookbook, ICookbookType
    {
        public CookbookJson(string fileName) : base(fileName)
        {

        }
        public override List<Recipe> ReadCookbook()
        {
            var cookbook = OpenCookbook();
            if (cookbook == null) return new List<Recipe>();

            List<string> recipesIDs = new List<string>();

            using (var reader = new StreamReader(cookbook))
            {
                while (!reader.EndOfStream)
                {
                    recipesIDs = JsonSerializer.Deserialize<List<string>>(reader.ReadToEnd());
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
