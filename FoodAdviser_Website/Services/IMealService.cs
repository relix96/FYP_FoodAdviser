using FoodAdviserModels.Models;

namespace Food_Adviser.Services
{
    public interface IMealService
    {
        Task<Meal> GetRandomMeals();
        Task<List<MealResult>> SearchMealsName(String meals);
        Task<Meal> GetMealsByName(String meals);
        Task<Meal> GetMealsByFilter(String search);
    }
}
