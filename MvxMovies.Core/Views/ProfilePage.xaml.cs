using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace MvxMovies.Core.Views
{
    [MvxTabbedPagePresentationAttribute(Title = "Profile", Position =TabbedPosition.Tab)]
    public partial class ProfilePage : MvxContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
    }
}
