using SaveMyFridge.API.Data.Models;
using SaveMyFridge.Data;
using System;

namespace SaveMyFridge.API.Data
{
    public class DataSeeder
    {
        
        public static void SeedDatabase(AppDbContext context)
        {
            Console.WriteLine("Seeding database...");

            List<Recipe> recipes = [];
            List<Ingredients> ingredients = [];

            if (!context.Ingredients.Any())
            {
                ingredients.Add(new Ingredients
                {
                    Name = "Chicken",
                    Description = "Chicken"
                });
            }

            if (!context.Recipes.Any())
            {
                recipes.Add(new Recipe
                {
                    Name = "Chicken Soup",
                    Ingredients = ingredients,
                    Instructions = "Cook the chicken",
                    Image = "https://www.example.com/image.jpg"
                });
            }

            context.Ingredients.AddRange(ingredients);
            context.Recipes.AddRange(recipes);
            context.SaveChanges();
        }

    }
}
