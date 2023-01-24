using System;
using Xamarin.Forms;
using TripLog.Models;
using TripLog.Services;
using System.Threading.Tasks;

namespace TripLog.ViewModels
{
    public class NewEntryViewModel : BaseViewModel
    {
        readonly ILocationService _locationService;
        string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
                SaveCommand.ChangeCanExecute();
            }
        }

        double _latitude;
        public double Latitude
        {
            get { return _latitude; }
            set
            {
                _latitude = value;
                OnPropertyChanged();
            }
        }

        double _longitude;
        public double Longitude
        {
            get { return _longitude; }
            set
            {
                _longitude = value;
                OnPropertyChanged();
            }
        }

        DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        int _rating;
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        Command _saveCommand;
        public Command SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new Command(async () => await ExecuteSaveCommand(), CanSave));
            }
        }

        public NewEntryViewModel(INavService navService, ILocationService locationService) : base(navService)
        {
            _locationService = locationService;
            Date = DateTime.Today;
            Rating = 1;
        }

        async Task ExecuteSaveCommand()
        {


            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            try
            {
                //TODO
                var newItem = new TripLogEntry
                {
                    Title = Title,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Date = Date,
                    Rating = Rating,
                    Notes = Notes
                };

                //TODO: remove this in Chapter 6
                await Task.Delay(3000);

                //TODO: Persist Entry in a later chapter.
                await NavService.GoBack();
            }
            finally
            {
                IsBusy = false;
            }

        }

        bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        public override async Task Init()
        {
            var coords = await _locationService.GetGeoCoordinatesAsync();

            Latitude = coords.Latitude;
            Longitude = coords.Longitude;
        }
    }
}

