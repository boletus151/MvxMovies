using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Constants;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly IStorageService storageService;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, IStorageService storageService) : base(application, navigationService)
        {
            this.storageService = storageService;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            var username = storageService.Get<string>(StorageConstants.Username);
            if (string.IsNullOrEmpty(username))
            {
                NavigationService.Navigate<TabbedViewModel>().GetAwaiter().GetResult();

                //NavigationService.Navigate<LoginViewModel>().GetAwaiter().GetResult();
                return Task.CompletedTask;
            }
            else
            {
                NavigationService.Navigate<TabbedViewModel>().GetAwaiter().GetResult();
                return Task.CompletedTask;
            }
        }
    }
}
