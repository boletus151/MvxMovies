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

        public TabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.loaded = false;
        }

        public override async void ViewAppearing()
        {
            await ShowInitialViewModels();
            //base.ViewAppearing();
        }

        private async Task ShowInitialViewModels()
        {
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

            if (tasks.Any(e=>e.IsFaulted))
            {
                this.loaded = false;
            }
            else { this.loaded = true; }
        }
    }
}
