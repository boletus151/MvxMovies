using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvxMovies.AppServices.Contracts;

namespace MvxMovies.AppServices.Implementations
{
    public class DialogService : IDialogService
    {
        public IUserDialogs UserDialogs => throw new NotImplementedException();

        public async Task ShowDefaultLoadingDialog(Func<IProgress<double>, Task> action, string message = null, bool isCurrentScope = false)
        {
            await AiForms.Dialogs.Loading.Instance.StartAsync(action, "Loading", true);
        }
    }
}
