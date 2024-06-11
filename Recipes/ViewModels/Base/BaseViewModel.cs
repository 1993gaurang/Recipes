using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Recipes.Extensions;
using Recipes.Interfaces;
using Recipes.Interfaces.Navigation;

namespace Recipes.ViewModels.Base
{
	public partial class BaseViewModel : ObservableObject
    {
        public IRecipeDataService _recipeDataService;
        public INavigationService _navigationService;

        [ObservableProperty]
        bool isBusy;

		public BaseViewModel()
		{
            _recipeDataService = ServiceExtension.GetService<IRecipeDataService>();
            _navigationService = ServiceExtension.GetService<INavigationService>();
        }

        public virtual void Init(object args)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }
    }
}

