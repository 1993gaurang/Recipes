using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Models;
using Recipes.ViewModels.Base;

namespace Recipes.ViewModels
{
	public partial class MealDetailPageViewModel : BaseViewModel
	{
        [ObservableProperty]
        string selectedMealString;

        [ObservableProperty]
        Uri selectedMealImage;

        [ObservableProperty]
        string selectedMealInstructions;


        MealData SelectedMeal;
        MealDetail SelectedMealDetails;

        public MealDetailPageViewModel()
		{
		}

        public override void Init(object args)
        {
            base.Init(args);
            if (args != null && args is MealData mealData)
            {
                SelectedMeal = mealData;
                selectedMealString = SelectedMeal.StrMeal;
            }
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();
            if (await CheckInternetConnection())
            {
                FetchData();
            }
        }

        public void FetchData()
        {
            IsBusy = true;
            _ = _recipeDataService.GetMealsDetails(SelectedMeal.IdMeal)
                .ContinueWith(task =>
                {
                    IsBusy = false;
                    if (task.IsCompleted)
                    {
                        RecipeMealDetail recipeMeal = task.Result;
                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            SelectedMealDetails = recipeMeal.Meals.First();
                            SelectedMealImage = SelectedMealDetails.StrMealThumb;
                            SelectedMealInstructions = SelectedMealDetails.StrInstructions;
                        });
                    }
                });
        }
    }
}

