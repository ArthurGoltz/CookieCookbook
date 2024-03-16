using CookieCookbook.Ingredients.Interfaces;

namespace CookieCookbook.Ingredients;
public abstract class Ingredient : IIngredient
{
    public abstract int Id { get; }
    public abstract string Name { get; }
    public abstract string PreparingInstructions { get; }

    public string DescribeInstructions()
    {
        return $"{Name}. {PreparingInstructions}";
    }

    public override string ToString()
    {
        return $"{Id}. {Name}";
    }


}
