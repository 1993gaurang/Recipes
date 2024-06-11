using System;
using Recipes.Models;

namespace Recipes.Interfaces
{
	public interface IRecipeDataService
	{
        Task<RecipeCategories> GetRecipesCategories();
        Task<RecipeMeals> GetRecipesMeals(string category);
    }
}

