using System;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;
using MvxMovies.UI.Model.ReturnPageTypes;

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

        protected virtual void ReturningToViewModel(ReturnTypeBase result)
        {

        }
    }
}
