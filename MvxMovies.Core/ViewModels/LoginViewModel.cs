using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Constants;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IStorageService storageService;

        private string username;
        private string password;

        public LoginViewModel(INavigationService navigationService, IStorageService storageService) : base(navigationService, storageService)
        {
            this.storageService = storageService;
            this.LoginCommand = new MvxAsyncCommand(() => this.LoginCommandExecute());
        }

        public string Username
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                // Not working?????  this.LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                // Not working?????  this.LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public MvxAsyncCommand LoginCommand { get; }

        private bool LoginCommandCanExecute()
        {
            return !string.IsNullOrEmpty(this.Username) && !string.IsNullOrEmpty(this.Password);
        }

        private async Task LoginCommandExecute()
        {
            if (this.LoginCommandCanExecute())
            {
                this.storageService.Set(StorageConstants.Username, this.Username);
                await this.NavigationService.MvxNavigationService.Navigate<TabbedViewModel>();
            }
        }
    }
}
