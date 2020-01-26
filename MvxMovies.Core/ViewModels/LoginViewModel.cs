using System.Threading.Tasks;
using MvvmCross.Commands;
using MvxMovies.Common.Constants;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class LoginViewModel : MvxBaseViewModel
    {
        private string username;
        private string password;

        public LoginViewModel(IBaseViewModel baseViewModel) : base(baseViewModel)
        {
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
                this.BaseViewModel.StorageService.Set(StorageConstants.Username, this.Username);
                await this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<TabbedViewModel>();
            }
        }
    }
}
