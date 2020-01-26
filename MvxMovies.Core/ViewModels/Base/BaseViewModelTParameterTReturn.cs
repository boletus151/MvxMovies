using System;
using MvvmCross.ViewModels;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Contracts;

namespace MvxMovies.Core.ViewModels.Base
{
    public class BaseViewModel<TParameter,TResult> : MvxViewModel<TParameter,TResult>
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

        public override void Prepare(TParameter parameter)
        {
        }
    }
}
