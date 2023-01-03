using System;
using TripLog.Views;
using TripLog.Models;
using System.Threading.Tasks;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
        TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get { return _entry; }
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }
        public DetailViewModel()
        {
        }

        public override async Task Init(TripLogEntry logEntry)
        {
            await Task.CompletedTask;
            Entry = logEntry;
        }
    }
}

