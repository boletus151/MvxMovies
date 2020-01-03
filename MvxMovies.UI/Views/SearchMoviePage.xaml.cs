using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace MvxMovies.UI.Views
{
    [MvxTabbedPagePresentation(WrapInNavigationPage = true, Title = "Search")]
    public partial class SearchMoviePage : MvxContentPage
    {
        public SearchMoviePage()
        {
            InitializeComponent();
        }
    }
}
