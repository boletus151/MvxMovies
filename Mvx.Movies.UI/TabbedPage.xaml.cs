using System;
using System.Collections.Generic;
using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace MvxMovies.UI
{
    [MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = true)]
    public partial class TabbedPage : MvvmCross.Forms.Views.MvxTabbedPage
    {
        public TabbedPage()
        {
            InitializeComponent();
        }
    }
}
