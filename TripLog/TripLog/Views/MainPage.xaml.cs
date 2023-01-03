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
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }

        void New_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewEntryPage());
        }

        async void Trips_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var trip = (TripLogEntry)e.Item;
            await Navigation.PushAsync(new DetailPage(trip));

            //Clear selection
            trips.SelectedItem = null;
        }
    }
}

