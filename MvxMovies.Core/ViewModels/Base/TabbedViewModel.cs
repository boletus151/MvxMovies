using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MvxMovies.AppServices.Contracts;

namespace MvxMovies.Core.ViewModels.Base
{
    public class TabbedViewModel : MvxBaseViewModel
    {
        private bool loaded;

        public TabbedViewModel(IBaseViewModel baseViewModel) : base(baseViewModel)
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
                this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<SearchMovieViewModel>(),
                this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<ProfileViewModel>()
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
