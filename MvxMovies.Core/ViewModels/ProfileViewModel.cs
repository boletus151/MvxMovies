using System;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigationService navigationService): base(navigationService)
        {
        }
    }
}
