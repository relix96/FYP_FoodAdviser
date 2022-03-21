using FoodAdviserModels.Models;

namespace Food_Adviser.Services
{
    public interface IMealService
    {
        Task<Meal> GetRandomMeals();
        Task<List<String>> SearchMealsByName(List<String> meals);
    }
}
