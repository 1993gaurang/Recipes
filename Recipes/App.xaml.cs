using Recipes.Extensions;
using Recipes.Interfaces.Navigation;
using Recipes.ViewModels;

namespace Recipes;

public partial class App : Application
{
    INavigationService navigationService;
    public App()
	{
		InitializeComponent();
        navigationService = ServiceExtension.GetService<INavigationService>();
        navigationService.SetMainViewModel<RecipeCategoryPageViewModel>();
    }
}

