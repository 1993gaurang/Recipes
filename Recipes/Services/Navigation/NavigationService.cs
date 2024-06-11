using System;
using Recipes.Interfaces.Navigation;
using Recipes.ViewModels.Base;
using Recipes.Views.Base;

namespace Recipes.Services.Navigation
{
	public class NavigationService : INavigationService
    {
        protected INavigation Navigation { get; private set; }
        public NavigationService()
		{
		}

        public void SetMainViewModel<T>(object args = null) where T : BaseViewModel
        {
            var page = ResolvePageAndViewModel(typeof(T), args);
            if (page != null)
            {
                var navigationPage = new NavigationPage(page);
                Navigation = navigationPage.Navigation;
                //setting the app's navigation context to Sign in page and its stack.
                ((App)Application.Current).MainPage = navigationPage;
            }
        }

        public async Task NavigateToAsync<T>(object args = null) where T : BaseViewModel
        {
            var page = ResolvePageAndViewModel(typeof(T), args);
            if (page != null && Navigation != null)
            {
                await Navigation.PushAsync(page);
            }
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
            {
                await Navigation.PopAsync();
            }
        }

        private Page ResolvePageAndViewModel(Type viewModelType, object args)
        {
            Page page = null;
            var pageType = FindPageTypeForViewModel(viewModelType);
            if(pageType != null)
            {
                var basePage = Activator.CreateInstance(pageType) as BaseContentPage;
                basePage.InitViewModel(args);
                page = basePage as Page;
            }
            
            return page;
        }

        private Type FindPageTypeForViewModel(Type viewModelType)
        {
            var pageTypeName = string.Empty;

            pageTypeName = viewModelType
                .AssemblyQualifiedName
                .Replace("ViewModels", "Views")
                .Replace("ViewModel", "");

            var pageType = Type.GetType(pageTypeName);

            if (pageType == null)
                throw new ArgumentException("Can't find a page of type '" + pageTypeName + "' for ViewModel '" +
                                            viewModelType.Name +
                                            "'");

            return pageType;
        }
    }
}

