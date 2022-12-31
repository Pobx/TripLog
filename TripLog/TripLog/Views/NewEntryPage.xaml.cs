using System;
using System.Collections.Generic;

using Xamarin.Forms;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public partial class NewEntryPage : ContentPage
    {
        public NewEntryPage()
        {
            InitializeComponent();
            BindingContext = new NewEntryViewModel();
        }
    }
}

