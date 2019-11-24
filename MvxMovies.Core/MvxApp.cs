using System;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxMovies.Common.Constants;
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
            
            Barrel.ApplicationId = AppInfo.Name;

            var mvxNavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.RegisterSingleton(typeof(INavigationService), new NavigationService(mvxNavigationService));

            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
            Mvx.IoCProvider.RegisterType<IMoviesService, MoviesServiceMock>();
            Mvx.IoCProvider.RegisterType<IStorageService, StorageServiceMonkeyCache>();

            this.SetAppStart();
        }

        private void SetAppStart()
        {
            var storageService = Mvx.IoCProvider.Resolve<IStorageService>();
            if (storageService is null)
            {
                throw new Exception($"{AppConstants.MvxMovieException}: StorageService is Null");
            }
            var username = storageService.Get<string>(StorageConstants.Username);
            if (string.IsNullOrEmpty(username))
            {
                RegisterAppStart<FirstViewModel>();
            }
            else
            {
                RegisterAppStart<SearchMovieViewModel>();
            }
        }
    }
}
