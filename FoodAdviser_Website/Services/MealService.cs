using Food_Adviser.Services;
using FoodAdviserModels.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        public async Task<List<MealResult>> SearchMealsName(String mealName)
        {   
            return await httpClient.GetFromJsonAsync<List<MealResult>>($"api/Meal/SearchMealsName/{mealName}");
        }

        public async Task<Meal> GetMealsByName(String meals) =>
            await httpClient.GetFromJsonAsync<Meal>($"api/Meal/SearchMealsByName/{meals}");

        public async Task<Meal> GetMealsByFilter(string search)
        {
            return await httpClient.GetFromJsonAsync<Meal>($"api/Meal/SearchMealsByFilters/{search}");
        }


        public async Task<Meal> GetMealsById(string id)
        {
            return await httpClient.GetFromJsonAsync<Meal>($"api/Meal/SearchMealsById/{id}");
        }
    }
}
