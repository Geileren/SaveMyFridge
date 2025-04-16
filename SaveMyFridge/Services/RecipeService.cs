using SaveMyFridge.Lib.Models;

namespace SaveMyFridge.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly List<Recipe> recipes = [];

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return Task.FromResult(recipes);
        }

        public Task AddRecipeAsync(Recipe recipe)
        {
            recipes.Add(recipe);
            return Task.CompletedTask;
        }
    }
}
