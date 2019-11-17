using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        public FirstViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.LoginCommand = new MvxCommand(() => this.NavigationService.MvxNavigationService.Navigate<SearchMovieViewModel>());
        }

        public ICommand LoginCommand { get; }
    }
}
