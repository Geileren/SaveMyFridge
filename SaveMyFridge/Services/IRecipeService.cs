﻿using SaveMyFridge.Lib.Models;

namespace SaveMyFridge.Services
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesAsync();
        Task AddRecipeAsync(Recipe recipe);
    }
}
