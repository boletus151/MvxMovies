using System;
using System.Threading.Tasks;
using MvvmCross.Logging;
using MvxMovies.AppServices.Contracts;

namespace MvxMovies.Core.ViewModels.Base
{
    public interface IBaseViewModel
    {
        INavigationService NavigationService { get; }

        IMvxLog Log { get; }

        IDialogService DialogService { get; }

        IStorageService StorageService { get; }

        bool ShouldNavigateToLogin { get; set; }

        bool IsBusy { get; set; }

        bool ShowErrorMessage { get; set; }

        string ErrorMessageString { get; set; }

        Task<bool> AccessAllowed(bool allowed);
    }
}
