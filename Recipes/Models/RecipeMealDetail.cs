using System;
using Newtonsoft.Json;

namespace Recipes.Models
{
	public class RecipeMealDetail
	{
        [JsonProperty("meals")]
        public List<MealDetail> Meals { get; set; }
    }

    public class MealDetail
	{
        [JsonProperty("strMeal")]
        public string StrMeal { get; set; }

        [JsonProperty("strMealThumb")]
        public Uri StrMealThumb { get; set; }

        [JsonProperty("strInstructions")]
        public string StrInstructions { get; set; }
    }
}

