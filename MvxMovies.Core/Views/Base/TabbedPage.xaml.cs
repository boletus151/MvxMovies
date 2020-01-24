using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace MvxMovies.Core.Views.Base
{
    [MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = false, WrapInNavigationPage =true)]
    public partial class TabbedPage : MvvmCross.Forms.Views.MvxTabbedPage
    {
        public TabbedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
