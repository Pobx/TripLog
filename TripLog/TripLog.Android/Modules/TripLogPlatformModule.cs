using System;
using Ninject.Modules;
using TripLog.Droid.Services;
using TripLog.Services;

namespace TripLog.Droid.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public TripLogPlatformModule()
        {
        }

        public override void Load()
        {
            Bind<ILocationService>().To<LocationService>().InSingletonScope();
        }
    }
}

