using MonkeyCache.FileStore;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Implementations;
using MvxMovies.Core.ViewModels;
using MvxMovies.Services.Contracts;
using MvxMovies.Services.Implementations;
using MvxMovies.Services.Implementations.Mocks;
using Xamarin.Essentials;

namespace MvxMovies.Core
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<FirstViewModel>();

            Barrel.ApplicationId = AppInfo.Name;

            var mvxNavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.RegisterSingleton(typeof(INavigationService), new NavigationService(mvxNavigationService));

            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
            Mvx.IoCProvider.RegisterType<IMoviesService, MoviesServiceMock>();
            Mvx.IoCProvider.RegisterType<IStorageService, StorageServiceMonkeyCache>();

        }
    }
}
