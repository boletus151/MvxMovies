using System;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;

namespace MvxMovies.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        protected INavigationService NavigationService { get; private set; }

        public BaseViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        protected void OnException(Exception ex)
        {
            Console.WriteLine($"EXCEPTION: {ex.Message}");
        }
    }
}
