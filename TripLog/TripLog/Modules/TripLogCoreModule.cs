using System;
using Ninject.Modules;
using TripLog.ViewModels;

namespace TripLog.Modules
{
	public class TripLogCoreModule : NinjectModule
	{
		public TripLogCoreModule()
		{
		}

        public override void Load()
        {
            //ViewModels
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();
        }
    }
}

