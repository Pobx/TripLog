using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TripLog.Models;
using TripLog.Views;
using TripLog.ViewModels;
using TripLog.Services;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm
        {
            get { return BindingContext as MainViewModel; }
        }

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }

        void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;

            _vm.ViewCommand.Execute(trip);
            //Clear selection
            trips.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Initialize MainViewModel
            if (_vm != null)
            {
                await _vm.Init();
            }
        }
    }
}

