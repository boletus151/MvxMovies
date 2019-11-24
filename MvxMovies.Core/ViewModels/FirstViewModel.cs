using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvxMovies.Common.Constants;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        private readonly IStorageService storageService;

        private string username;
        private string password;

        public FirstViewModel(INavigationService navigationService, IStorageService storageService) : base(navigationService)
        {
            this.storageService = storageService;
            this.LoginCommand = new MvxAsyncCommand(() => this.LoginCommandExecute(), () => !string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password));
        }

        private async Task LoginCommandExecute()
        {
            await this.storageService.Set(StorageConstants.Username, this.Username);
            await this.NavigationService.MvxNavigationService.Navigate<SearchMovieViewModel>();
        }

        public string Username { get => username; set => SetProperty(ref username, value); }

        public string Password { get => password; set => SetProperty(ref password, value); }

        public ICommand LoginCommand { get; }
    }
}
