﻿using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Recipes.Extensions;
using Recipes.Interfaces;
using Recipes.Interfaces.Navigation;
using Recipes.Models;
using Recipes.ViewModels.Base;

namespace Recipes.ViewModels
{
	public partial class RecipeCategoryPageViewModel : BaseViewModel
    {

        [ObservableProperty]
        ObservableCollection<CategoriesData> recipeCategories;

        public RecipeCategoryPageViewModel()
		{
        }

        [RelayCommand]
        private async Task CategoryClicked(CategoriesData categoriesData)
        {
            await _navigationService.NavigateToAsync<CategoryMealsPageViewModel>(categoriesData);
        }

        public override void Init(object args)
        {
            base.Init(args);
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
            if (RecipeCategories == null || !RecipeCategories.Any())
            {
                IsBusy = true;
                _ = _recipeDataService.GetRecipesCategories()
                    .ContinueWith(task =>
                    {
                        IsBusy = false;
                        if (task.IsCompletedSuccessfully)
                        {
                            RecipeCategories recipeCategories = task.Result;
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                RecipeCategories = new ObservableCollection<CategoriesData>(recipeCategories.Categories);
                            });
                        }
                    });
            }
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}

