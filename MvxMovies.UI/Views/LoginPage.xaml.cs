using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace MvxMovies.UI.Views
{
    [MvxContentPagePresentation(Title = "Login", NoHistory = true, WrapInNavigationPage =false)]
    public partial class LoginPage : MvxContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
