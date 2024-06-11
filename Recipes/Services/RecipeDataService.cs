using System;
using Newtonsoft.Json;
using Recipes.Interfaces;
using Recipes.Models;

namespace Recipes.Services
{
	public class RecipeDataService : IRecipeDataService
    {


        public HttpClient Client;

        public RecipeDataService()
		{

            Client = new HttpClient();
        }

        public async Task<RecipeCategories> GetRecipesCategories()
        {
            var url = "https://www.themealdb.com/api/json/v1/1/categories.php";
            var tcs = new TaskCompletionSource<RecipeCategories>();

            _=Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await Client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<RecipeCategories>(responseContent);
                        tcs.SetResult(data);
                    }
                    else
                    {
                        tcs.SetResult(null);
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return await tcs.Task;
        }

        public async Task<RecipeMeals> GetRecipesMeals(string category)
        {
            var url = String.Format("https://www.themealdb.com/api/json/v1/1/filter.php?c={0}", category);
            var tcs = new TaskCompletionSource<RecipeMeals>();

            _ = Task.Run(async () =>
            {
                try
                {
                    HttpResponseMessage response = await Client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<RecipeMeals>(responseContent);
                        tcs.SetResult(data);
                    }
                    else
                    {
                        tcs.SetResult(null);
                    }
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            });

            return await tcs.Task;
        }
    }
}

