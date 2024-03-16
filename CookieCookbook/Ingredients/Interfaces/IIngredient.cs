namespace CookieCookbook.Ingredients.Interfaces;
public interface IIngredient
{
    int Id { get; }
    string Name { get; }
    string PreparingInstructions { get; }

    string DescribeInstructions();

}
