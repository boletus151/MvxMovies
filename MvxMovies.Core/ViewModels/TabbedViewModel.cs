using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MvxMovies.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        public TabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        public override async void ViewAppearing()
        {
            await ShowInitialViewModels();
            base.ViewAppearing();
        }

        private async Task ShowInitialViewModels()
        {
            var tasks = new List<Task>();
            tasks.Add(NavigationService.MvxNavigationService.Navigate<SearchMovieViewModel>());
            tasks.Add(NavigationService.MvxNavigationService.Navigate<ProfileViewModel>());
            await Task.WhenAll(tasks);
        }
    }
}
