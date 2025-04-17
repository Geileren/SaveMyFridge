namespace SaveMyFridge.Lib.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public required string Name { get; set; }
    public string? Discription { get; set; }

    public DateTime? ExpirationDate { get; set; }
    public decimal? Price { get; set; }
    public decimal? Quantity { get; set; }
    public string? Unit { get; set; }

    public List<Recipe> Recipes { get; set; } = [];
}