using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TripLog.Views;
using TripLog.Services;
using TripLog.ViewModels;

namespace TripLog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());

            var mainPage = new NavigationPage(new MainPage());
            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            navService.XamarinFormsNav = mainPage.Navigation;
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

