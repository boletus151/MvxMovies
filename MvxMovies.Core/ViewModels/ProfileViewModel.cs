using System;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigationService navigationService): base(navigationService)
        {
        }

        public override async Task Initialize()
        {
            await Task.Delay(5000);
        }
    }
}
