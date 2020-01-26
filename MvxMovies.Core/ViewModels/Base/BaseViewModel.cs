using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MvvmCross.Logging;
using MvvmCross.ViewModels;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Constants;
using MvxMovies.UI.Model.ReturnPageTypes;

namespace MvxMovies.Core.ViewModels.Base
{
    public class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
        private bool isBusy;
        private bool showMessageError;
        private string messageError;

        public BaseViewModel(INavigationService navigationService, IDialogService dialogService, IStorageService storageService)
        {
            this.StorageService = storageService;
            this.NavigationService = navigationService;
            this.DialogService = dialogService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IStorageService StorageService { get; private set; }

        public INavigationService NavigationService { get; private set; }

        public IDialogService DialogService { get; private set; }

        public IMvxLog Log { get; private set; }

        public bool ShouldNavigateToLogin { get; set; }

        public Task<bool> AccessAllowed(bool allowed = true)
        {
            if (!allowed) // mock this value
            {
                this.ShouldNavigateToLogin = true;
            }
            this.StorageService.Remove(StorageConstants.Username);

            return Task.FromResult(allowed);
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; NotifyPropertyChanged(); }
        }

        public bool ShowErrorMessage
        {
            get { return showMessageError; }
            set { showMessageError = value; NotifyPropertyChanged(); }
        }

        public string ErrorMessageString
        {
            get { return messageError; }
            set { messageError = value; NotifyPropertyChanged(); }
        }
        
        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
