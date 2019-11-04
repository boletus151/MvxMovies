using System;
using MvvmCross.ViewModels;

namespace MvxMovies.Model
{
    public class Movie : MvxNotifyPropertyChanged
    {
        private string title;

        public string Plot { get; set; }

        public decimal Rating { get; set; }

        public string Image { get; set; }

        public string Title
        {
            get => title;
            set
            {
                SetProperty(ref title, value);
            }
        }
    }
}
