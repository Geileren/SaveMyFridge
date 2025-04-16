using System.ComponentModel.DataAnnotations;

namespace SaveMyFridge.Lib.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingredient name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0.01, 10000, ErrorMessage = "Quantity must be greater than 0")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Unit is required")]
        public string Unit { get; set; } = string.Empty;

        public DateTime? ExpiryDate { get; set; }

        // Optional properties that might be useful
        public string? Category { get; set; }
        public bool IsStaple { get; set; } = false; // For common ingredients always kept in stock
        public string? Description { get; set; }
        public string? Macros { get; set; }
        public List<Recipe> Recipes { get; set; } = [];
    }
}