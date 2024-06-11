using System;
using Newtonsoft.Json;

namespace Recipes.Models
{
	public class RecipeCategories
	{
        [JsonProperty("categories")]
        public List<CategoriesData> Categories { get; set; }
    }

    public class CategoriesData
    {
        [JsonProperty("idCategory")]
        public string IdCategory { get; set; }

        [JsonProperty("strCategory")]
        public string StrCategory { get; set; }

        [JsonProperty("strCategoryThumb")]
        public Uri StrCategoryThumb { get; set; }

        [JsonProperty("strCategoryDescription")]
        public string StrCategoryDescription { get; set; }
    }
}

