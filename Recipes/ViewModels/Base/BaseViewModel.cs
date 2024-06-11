using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Recipes.ViewModels.Base
{
	public class BaseViewModel : ObservableObject
    {
		public BaseViewModel()
		{
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

