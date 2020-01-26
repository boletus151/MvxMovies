using System;
using System.Threading.Tasks;

namespace MvxMovies.AppServices.Contracts
{
    public interface IDialogService
    {
        Task ShowDefaultLoadingDialog();
    }
}
