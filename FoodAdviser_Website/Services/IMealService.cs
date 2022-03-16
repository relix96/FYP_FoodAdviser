using FoodAdviserModels.Models;

namespace Food_Adviser.Services
{
    public interface IMealService
    {
        Task<Meal> GetRandomMeals();
    }
}
