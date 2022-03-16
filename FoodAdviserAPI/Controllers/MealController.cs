using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodAdviserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {

        [HttpGet]
        [Route("GetRandomMeals")]
        public async Task<IActionResult> GetRandomMealsAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/random?number=12"),
                Headers =
                    {
                        { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                        { "x-rapidapi-key", "da795d761emshe955b1ccb3626e8p1766a7jsn9f3618b4b169" },

                    },
            };

            using (var response = await client.SendAsync(request))
            {
                try { 
                    if (response.IsSuccessStatusCode)
                    {
                        string body = response.Content.ReadAsStringAsync().Result;
                        var test = JsonConvert.DeserializeObject(body);
                        //Console.Clear();
                        //Console.WriteLine(test);
                        if (body != null)
                        {
                            Meal meals = JsonConvert.DeserializeObject<Meal>(body);
                            return Ok(meals);
                        }

                        else return BadRequest(body.ToString());
                    }
                        else return BadRequest();
                }
                catch(Exception ex)
                {
                   return BadRequest(ex.Message);
                }
               

            }
        }

        private List<Meal> GetRandomMeals(string body)
        {
            List<Meal> meals = JsonConvert.DeserializeObject<List<Meal>>(body);
            return meals;

        }


    }


}
