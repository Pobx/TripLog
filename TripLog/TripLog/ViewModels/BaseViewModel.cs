using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TripLog.Services;

namespace TripLog.Views
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected INavService NavService { get; private set; }

        protected BaseViewModel(INavService navService) : base()
        {
            NavService = navService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract Task Init();
    }

    public abstract class BaseViewModel<TParameter> : BaseViewModel
    {
        protected BaseViewModel(INavService navService) : base(navService)
        {

        }

        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);

    }
}

