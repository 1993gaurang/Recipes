using System;
using Recipes.ViewModels.Base;

namespace Recipes.Interfaces.Navigation
{
	public interface INavigationService
	{
        void SetMainViewModel<T>(object args = null) where T : BaseViewModel;
        Task NavigateToAsync<T>(object args = null) where T : BaseViewModel;
        Task PopAsync();
    }
}

