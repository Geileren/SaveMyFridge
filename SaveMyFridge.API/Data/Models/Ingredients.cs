namespace SaveMyFridge.API.Data.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Macros { get; set; }
        public List<Recipe> Recipes { get; set; } = [];
    }
}
