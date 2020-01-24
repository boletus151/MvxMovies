using System.Diagnostics;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using MvxMovies.Core.ViewModels;

namespace MvxMovies.Core.Views
{
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, WrapInNavigationPage = true, NoHistory = true)]
    public partial class SearchMoviePage : MvxContentPage
    {
        private string initializizeTaskProperty;

        public SearchMoviePage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            var vm = this.DataContext as SearchMovieViewModel;
            if (vm is null)
            {
                return;
            }

            vm.OnViewModelSet();

            //this.initializizeTaskProperty = nameof(vm.InitializeTask.IsCompleted);

            //vm.InitializeTask.PropertyChanged += this.InitializeTask_PropertyChanged;
        }
        private void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == this.initializizeTaskProperty)
            {
                var vm = this.DataContext as SearchMovieViewModel;
                if (vm.ShouldNavigateToLogin)
                {
                    vm.NavigationService.MvxNavigationService.Navigate<LoginViewModel>();
                }
            }
        }
    }
}
