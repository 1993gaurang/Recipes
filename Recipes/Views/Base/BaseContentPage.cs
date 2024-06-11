using System;
using System.Linq.Expressions;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Recipes.ViewModels.Base;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;

namespace Recipes.Views.Base
{
	public class BaseContentPage : ContentPage
    {
        BaseViewModel baseViewModel;
        public BaseContentPage()
		{
            On<iOS>().SetUseSafeArea(false);
            NavigationPage.SetHasNavigationBar(this, false);
            HideSoftInputOnTapped = true;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if(BindingContext is BaseViewModel)
            {
                baseViewModel = BindingContext as BaseViewModel;
            }
        }

        public void InitViewModel(object args = null)
        {
            baseViewModel?.Init(args);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            baseViewModel?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            baseViewModel?.OnDisappearing();
        }

        public void SetBinding<TSource>(
            BindableProperty targetProperty,
            Expression<Func<TSource, object>> sourceProperty,
            BindingMode mode = BindingMode.Default,
            IValueConverter converter = null,
            string stringFormat = null)
        {
            (this as BindableObject).SetBinding(targetProperty, sourceProperty.ToString(), mode,
                converter, stringFormat);
        }
    }
}

