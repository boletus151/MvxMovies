using System;
using System.Threading.Tasks;
using AiForms.Dialogs;
using AiForms.Dialogs.Abstractions;
using MvxMovies.AppServices.Contracts;
using Xamarin.Forms;

namespace MvxMovies.AppServices.Implementations
{
    public class DialogService : IDialogService
    {
        public async Task ShowDefaultLoadingDialog()
        {
            // Loading settings
            Configurations.LoadingConfig = new LoadingConfig
            {
                IndicatorColor = Color.White,
                OverlayColor = Color.Black,
                Opacity = 0.4,
                DefaultMessage = "Loading...",
            };

            await Loading.Instance.StartAsync(async progress => {
                // some heavy process.
                for (var i = 0; i < 10; i++)
                {
                    await Task.Delay(50);
                    // can send progress to the dialog with the IProgress.
                    progress.Report((i + 1) * 0.01d);
                }
            });
        }
    }
}
