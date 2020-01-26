using System;
using MvvmCross.ViewModels;

namespace MvxMovies.UI.Model
{
    public class Movie : MvxNotifyPropertyChanged
    {
        private bool _checkedMovie;

        public string Id { get; set; }

        public string Plot { get; set; }

        public decimal Rating { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public bool Checked { get => _checkedMovie; set => SetProperty(ref _checkedMovie, value); }
    }
}
