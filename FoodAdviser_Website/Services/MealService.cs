using Food_Adviser.Services;
using FoodAdviserModels.Models;

namespace Food_Adviser.Services
{
    public class MealService:IMealService
    {

        private readonly HttpClient httpClient;

        public MealService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public async Task<Meal> GetRandomMeals() =>
            await httpClient.GetFromJsonAsync<Meal>("api/Meal/GetRandomMeals");
    }
}
