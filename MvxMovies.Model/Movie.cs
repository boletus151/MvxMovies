using System;
using MvvmCross.ViewModels;

namespace MvxMovies.UI.Model
{
    public class Movie : MvxNotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Plot { get; set; }

        public decimal Rating { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }
    }
}
