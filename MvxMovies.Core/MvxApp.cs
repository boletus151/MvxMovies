using MonkeyCache.FileStore;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxMovies.AppServices.Contracts;
using MvxMovies.AppServices.Implementations;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Implementations;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.Services.Implementations;
using Xamarin.Essentials;

namespace MvxMovies.Core
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            
            Barrel.ApplicationId = AppInfo.Name;

            var mvxNavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.RegisterSingleton(typeof(INavigationService), new NavigationService(mvxNavigationService));
            Mvx.IoCProvider.RegisterType<IDialogService,DialogService>();
            Mvx.IoCProvider.RegisterType<IBaseViewModel,BaseViewModel>();

            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
            Mvx.IoCProvider.RegisterType<IMoviesService, MoviesService>();
            Mvx.IoCProvider.RegisterType<IStorageService, StorageServiceMonkeyCache>();

            RegisterCustomAppStart<AppStart>();
        }
    }
}
