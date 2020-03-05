using System;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace MvxMovies.AppServices.Contracts
{
    public interface IDialogService
    {
        IUserDialogs UserDialogs { get; }

        Task ShowDefaultLoadingDialog(Func<IProgress<double>, Task> action, string message = null, bool isCurrentScope = false);
    }
}
