using SaveMyFridge.Lib.Models;
using SaveMyFridge.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveMyFridge.API.Data
{
    public class DataSeeder
    {
        /// <summary>
        /// Seeds the database with initial data.
        /// </summary>
        /// <param name="context">The database context.</param>
        /// <param name="clearExistingData">If true, will remove all existing data before seeding.</param>
        public static void SeedDatabase(AppDbContext context, bool clearExistingData = false)
        {
            Console.WriteLine("Seeding database...");

            if (clearExistingData)
            {
                ClearAllData(context);
                Console.WriteLine("Existing data cleared.");
            }

            List<Ingredient> ingredients = [];

            // Add ingredients
            if (!context.Ingredients.Any())
            {
                Console.WriteLine("Adding ingredients...");
                ingredients.Add(new Ingredient
                {
                    Name = "Chicken",
                    Description = "Chicken",
                    Quantity = 500,
                    Unit = "g",
                    ExpiryDate = DateTime.Now.AddDays(7)
                });

                ingredients.Add(new Ingredient
                {
                    Name = "Carrot",
                    Description = "Fresh carrot",
                    Quantity = 200,
                    Unit = "g",
                    ExpiryDate = DateTime.Now.AddDays(14)
                });

                ingredients.Add(new Ingredient
                {
                    Name = "Onion",
                    Description = "Yellow onion",
                    Quantity = 150,
                    Unit = "g",
                    ExpiryDate = DateTime.Now.AddDays(30)
                });

                context.Ingredients.AddRange(ingredients);
                context.SaveChanges();
            }

            // Add recipes
            if (!context.Recipes.Any())
            {
                Console.WriteLine("Adding recipes...");

                // If we're not clearing data but there are existing ingredients,
                // we need to load them from the database
                if (ingredients.Count == 0)
                {
                    ingredients = context.Ingredients.ToList();
                }

                var recipe = new Recipe
                {
                    Name = "Chicken Soup",
                    Instructions = "1. In a large pot, cook the chicken until browned.\n2. Add chopped carrots and onions.\n3. Add water and simmer for 30 minutes.\n4. Season with salt and pepper to taste.",
                    Image = "https://www.example.com/image.jpg",
                    Ingredients = new List<Ingredient>
                    {
                        ingredients[0], // Chicken
                        ingredients[1], // Carrot
                        ingredients[2]  // Onion
                    }
                };


                context.Recipes.Add(recipe);
                context.SaveChanges();
            }

            Console.WriteLine("Database seeding completed.");
        }

        /// <summary>
        /// Clears all data from the database.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void ClearAllData(AppDbContext context)
        {
            // The order is important due to foreign key constraints

            // First clear any relationships between recipes and ingredients
            // This assumes you have a many-to-many relationship with a join table
            // If you have a different relationship, you may need to adjust this
            var recipes = context.Recipes.Include(r => r.Ingredients).ToList();
            foreach (var recipe in recipes)
            {
                recipe.Ingredients.Clear();
            }
            context.SaveChanges();

            // Then clear the recipes
            context.Recipes.RemoveRange(context.Recipes);
            context.SaveChanges();

            // Finally clear the ingredients
            context.Ingredients.RemoveRange(context.Ingredients);
            context.SaveChanges();
        }
    }
}