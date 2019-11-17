using System;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel
    {
        public MovieDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
