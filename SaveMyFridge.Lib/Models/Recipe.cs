namespace SaveMyFridge.Lib.Models;

public class Recipe
{
    public int RecipeId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Auhtor { get; set; }
    public int? CookTime { get; set; }
    public bool IsFavorite { get; set; } = false;
    public List<Ingredient> Ingredients { get; set; } = [];
}