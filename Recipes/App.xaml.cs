using Recipes.Extensions;
using Recipes.Interfaces.Navigation;
using Recipes.ViewModels;

namespace Recipes;

public partial class App : Application
{
    INavigationService _navigationService;
    public App()
	{
		InitializeComponent();
        _navigationService = ServiceExtension.GetService<INavigationService>();
        _navigationService.SetMainViewModel<RecipeCategoryPageViewModel>();
    }
}

