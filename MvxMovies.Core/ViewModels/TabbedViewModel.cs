using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MvxMovies.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        private bool loaded;

        public TabbedViewModel(INavigationService navigationService, IStorageService storageService) : base(navigationService, storageService)
        {
            this.loaded = false;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await ShowInitialViewModels();
        }

        private async Task ShowInitialViewModels()
        {
            // avoid reload tabs if they are already loaded
            if (this.loaded)
            {
                return;
            }
            var tasks = new List<Task>
            {
                NavigationService.MvxNavigationService.Navigate<SearchMovieViewModel>(),
                NavigationService.MvxNavigationService.Navigate<ProfileViewModel>()
            };
            await Task.WhenAll(tasks);

            if (tasks.Any(e => e.IsFaulted))
            {
                this.loaded = false;
            }
            else { this.loaded = true; }
        }
    }
}
