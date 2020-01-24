using System;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using MvxMovies.Common.Constants;
using MvxMovies.Common.Contracts;
using MvxMovies.UI.Model.ReturnPageTypes;

namespace MvxMovies.Core.ViewModels.Base
{
    public class BaseViewModel : MvxViewModel
    {
        protected string InitTaskIsCompleatedProperty;

        public IStorageService StorageService { get; private set; }
        public INavigationService NavigationService { get; private set; }

        public BaseViewModel(INavigationService navigationService, IStorageService storageService)
        {
            this.StorageService = storageService;
            this.NavigationService = navigationService;
        }

        public bool ShouldNavigateToLogin { get; set; }

        protected void OnException(Exception ex)
        {
            Console.WriteLine($"EXCEPTION: {ex.Message}");
        }

        protected virtual void ReturningToViewModel(ReturnTypeBase result)
        {

        }

        /// <summary>
        /// This method should be called in every View Code Behind when you
        /// need to subscribe to InitializeTask changes.
        /// </summary>
        public void OnViewModelSet()
        {
            this.InitTaskIsCompleatedProperty = nameof(this.InitializeTask.IsCompleted);
            if (this.InitializeTask is null)
            {
                return;
            }
            this.InitializeTask.PropertyChanged += this.InitializeTask_PropertyChanged;
        }

        public bool AccessAllowed(bool allowed = true)
        {
            if (!allowed) // mock this value
            {
                this.ShouldNavigateToLogin = true;
            }
            this.StorageService.Remove(StorageConstants.Username);

            return allowed;
        }

        private void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.InitTaskIsCompleatedProperty)
            {
                if (this.ShouldNavigateToLogin)
                {
                    this.NavigationService.MvxNavigationService.Navigate<LoginViewModel>();
                }
            }
        }
    }
}
