using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TripLog.Views;
using TripLog.Services;
using TripLog.ViewModels;
using Ninject.Modules;
using Ninject;
using TripLog.Modules;

namespace TripLog
{
    public partial class App : Application
    {
        public IKernel Kernel { get; set; }
        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());

            //var mainPage = new NavigationPage(new MainPage());
            //var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            //navService.XamarinFormsNav = mainPage.Navigation;
            //navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            //navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailPage));
            //navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryPage));

            var mainPage = new NavigationPage(new MainPage());

            //Register core services
            Kernel = new StandardKernel(new TripLogCoreModule(), new TripLogNavModule(mainPage.Navigation));

            //Register platform specific services
            Kernel.Load(platformModules);

            //Get the MainViewModel from the Ioc
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

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

