using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using SaveMyFridge.Lib.Models;

namespace SaveMyFridge.Services
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(int id);
        Task<Ingredient> AddIngredientAsync(Ingredient ingredient);
        Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(int id);
    }

    public class IngredientService : IIngredientService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "api/ingredients";

        public IngredientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ingredient>>(_baseUrl) ?? new List<Ingredient>();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ingredient>($"{_baseUrl}/{id}") ?? new Ingredient();
        }

        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUrl, ingredient);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Ingredient>() ?? new Ingredient();
        }

        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/{ingredient.Id}", ingredient);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Ingredient>() ?? new Ingredient();
        }

        public async Task DeleteIngredientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}