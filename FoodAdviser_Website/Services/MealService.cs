using Food_Adviser.Services;
using FoodAdviserModels.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Food_Adviser.Services
{
    public class MealService:IMealService
    {

        private readonly HttpClient httpClient;

        public MealService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

 
        public async Task<Meal> GetRandomMeals()
        {
            return await httpClient.GetFromJsonAsync<Meal>("api/Meal/GetRandomMeals");
        }

        public async Task<List<MealResult>> SearchMealsName(String mealName) =>
            await httpClient.GetFromJsonAsync<List<MealResult>>($"api/Meal/SearchMealsName/{mealName}");

        public async Task<Meal> GetMealsByName(String meals) =>
            await httpClient.GetFromJsonAsync<Meal>($"api/Meal/SearchMealsByName/{meals}");


    }
}
