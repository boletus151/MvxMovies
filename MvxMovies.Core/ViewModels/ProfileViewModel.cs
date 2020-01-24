using System;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel(INavigationService navigationService, IStorageService storageService): base(navigationService,storageService)
        {
        }

        public override async Task Initialize()
        {
            await Task.Delay(5000);
        }
    }
}
