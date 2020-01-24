using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace MvxMovies.UI.Views
{
    [MvxTabbedPagePresentationAttribute(Position = TabbedPosition.Tab, WrapInNavigationPage = true, NoHistory = true)]
    public partial class SearchMoviePage : MvxContentPage
    {
        public SearchMoviePage()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
