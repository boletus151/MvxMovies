using System;
using MvvmCross.Navigation;
using MvxMovies.AppServices.Contracts;

namespace MvxMovies.AppServices.Implementations
{
    public class NavigationService : INavigationService
    {
        public IMvxNavigationService MvxNavigationService { get; private set; }

        public NavigationService(IMvxNavigationService navigationService)
        {
            this.MvxNavigationService = navigationService;
        }
    }
}
