using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace MvxMovies.UI.Views
{
    [MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "Profile")]
    public partial class ProfilePage : MvxContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}
