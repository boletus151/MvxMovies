using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class TabbedViewModel : BaseViewModel
    {
        public TabbedViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
