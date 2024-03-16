using CookieCookbook.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.Cookbook
{
    public interface ICookbookType
    {
        List<Recipe> ReadCookbook();
        Recipe WriteCookbook(List<Recipe> recipes);

    }
}
