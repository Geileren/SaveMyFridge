namespace SaveMyFridge.API.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required List<Ingredients> Ingredients { get; set; }
        public string? Instructions { get; set; }
        public string? Image { get; set; }
    }
}
