using System;
namespace Recipes.Extensions
{
    public class ServiceExtension
    {

        public static IServiceProvider Current =>
#if ANDROID
            MauiApplication.Current.Services;
#else
            MauiUIApplicationDelegate.Current.Services;
#endif


        public static TService GetService<TService>()
        {
            return Current.GetService<TService>();
        }
    }
}

