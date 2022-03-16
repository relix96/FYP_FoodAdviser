namespace Food_Adviser.Data
{
    public class IngredientService
    {

        public async Task<HttpResponseMessage> GetRandomRecipesAsync(int num) { 
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/random?tags=vegetarian%2Cdessert&number="+num),
                Headers =
            {

            { "x-rapidapi-host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
            { "x-rapidapi-key", "da795d761emshe955b1ccb3626e8p1766a7jsn9f3618b4b169" },
        },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();              
                Console.WriteLine(body);
                if (body.Count() > 0) { return new HttpResponseMessage(System.Net.HttpStatusCode.OK);}
                else return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);
        }


        }
    }

}
