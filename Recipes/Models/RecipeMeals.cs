using System;
using Newtonsoft.Json;

namespace Recipes.Models
{
	public class RecipeMeals
	{
        [JsonProperty("meals")]
        public List<MealData> Meals { get; set; }
    }

    public class MealData
    {
        [JsonProperty("strMeal")]
        public string StrMeal { get; set; }

        [JsonProperty("strMealThumb")]
        public Uri StrMealThumb { get; set; }

        [JsonProperty("idMeal")]
        public string IdMeal { get; set; }
    }
}

