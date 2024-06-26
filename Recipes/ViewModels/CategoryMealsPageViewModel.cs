﻿using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Models;
using Recipes.ViewModels.Base;

namespace Recipes.ViewModels
{
	public partial class CategoryMealsPageViewModel : BaseViewModel
    {
		[ObservableProperty]
		string selectedCategoryString;

        [ObservableProperty]
        ObservableCollection<MealData> recipeMeals;

        CategoriesData SelectedCategory;
        public CategoryMealsPageViewModel()
		{
		}

        [RelayCommand]
        private async Task MealClicked(MealData mealData)
        {
            await _navigationService.NavigateToAsync<MealDetailPageViewModel>(mealData);
        }

        public override void Init(object args)
        {
            base.Init(args);
            if(args != null && args is CategoriesData category)
            {
                SelectedCategory = category;
                SelectedCategoryString = SelectedCategory.StrCategory;
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
            if(RecipeMeals == null || !RecipeMeals.Any())
            {
                IsBusy = true;
                _ = _recipeDataService.GetRecipesMeals(SelectedCategory.StrCategory)
                    .ContinueWith(task =>
                    {
                        IsBusy = false;
                        if (task.IsCompleted)
                        {
                            RecipeMeals recipeMeals = task.Result;
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                RecipeMeals = new ObservableCollection<MealData>(recipeMeals.Meals);
                            });
                        }
                    });
            }
        }
    }
}

