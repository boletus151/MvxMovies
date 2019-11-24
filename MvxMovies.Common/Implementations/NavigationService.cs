using System;
using MvvmCross.Navigation;
using MvxMovies.Common.Contracts;

namespace MvxMovies.Common.Implementations
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
