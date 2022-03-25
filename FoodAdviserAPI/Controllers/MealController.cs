using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

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
            try
            {
                //string body = await getRandomMeals();
                string body = await getRandomMeals();
                if (body != null)
                {
                    Meal meals = JsonConvert.DeserializeObject<Meal>(body);
                    return Ok(meals);
                }
                else return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }
        [HttpGet]
        [Route("SearchMealsName/{MealName}")]
        public async Task<List<MealResult>> SearchMealsName(String MealName)
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/autocomplete?query={MealName}&number=100"),
                Headers =
                    {
                        { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                        { "x-rapidapi-key", "da795d761emshe955b1ccb3626e8p1766a7jsn9f3618b4b169" },

                    },
            };


            using (var response = await client.SendAsync(request))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //List<String> mealsNames = new List<String>();
                        string body = response.Content.ReadAsStringAsync().Result;
                        var test = JsonConvert.DeserializeObject(body);

                        if (body != null)
                        {
                            List<MealResult> mealsResults = JsonConvert.DeserializeObject<List<MealResult>>(body);
                            //mealsNames = mealsResults.Select(x => x.title).ToList();
                            //Meal meals = await GetMealsById(mealsResults);
                            return mealsResults != null ? mealsResults : null;
                        }

                        else return null;
                    }
                    else return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }



        [HttpGet]
        [Route("SearchMealsByName/{mealName}")]
        public async Task<IActionResult> GetSearchMealsByName(String mealName)
        {
            try
            {
                string meal = await getGetSearchMealsByNameAsync(mealName);

                if (meal != null)
                {
                    List<MealResult> mealsResults = JsonConvert.DeserializeObject<List<MealResult>>(meal);
                    Meal meals = await GetMealsById(mealsResults);
                    return meals != null ? Ok(meals) : BadRequest();
                }

                else return BadRequest();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        private async Task<Meal> GetMealsById(List<MealResult> mealsResult)
        {
            Meal meals = new Meal();
            try
            {
                foreach (var meal in mealsResult)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/" + meal.id + "/information"),
                        Headers =
                        {
                            { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                            { "x-rapidapi-key", "da795d761emshe955b1ccb3626e8p1766a7jsn9f3618b4b169" },
                        },
                    };
                    using (var response = await client.SendAsync(request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string body = response.Content.ReadAsStringAsync().Result;
                            var test = JsonConvert.DeserializeObject(body);
                            Recipe mealResult = JsonConvert.DeserializeObject<Recipe>(body);
                            meals.recipes.Add(mealResult);
                        }

                    }

                }
                return meals;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return meals = null;
            }

        }

        private async Task<String> getGetSearchMealsByNameAsync(String mealName)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/autocomplete?query={mealName}&number=100"),
                Headers =
                    {
                        { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                        { "x-rapidapi-key", "da795d761emshe955b1ccb3626e8p1766a7jsn9f3618b4b169" },

                    },
            };

            using (var response = await client.SendAsync(request))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string body = response.Content.ReadAsStringAsync().Result;
                        return body;
                    }

                    else { return null; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return null;
        }

        private async Task<String> getRandomMeals()
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
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string body = response.Content.ReadAsStringAsync().Result;
                        return body;
                        //var test = JsonConvert.DeserializeObject(body);
                    }
                    else return null;
                }
                catch (Exception ex) { Console.WriteLine(); }
            }

            return null;
        }
        

    }

}


