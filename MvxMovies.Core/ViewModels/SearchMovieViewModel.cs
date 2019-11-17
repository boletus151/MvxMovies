using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Mapper;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;

namespace MvxMovies.Core.ViewModels
{
    public class SearchMovieViewModel : BaseViewModel
    {
        private readonly IMoviesService moviesService;
        private string text;
        private MvxNotifyTask<bool> navigationTask;

        public SearchMovieViewModel(INavigationService navigationService, IMoviesService moviesService) : base(navigationService)
        {
            this.moviesService = moviesService;

            this.SearchCommand = new MvxAsyncCommand(async()=>await this.SearchCommandExecute());
            this.NavigateToMovieDetailCommand = new MvxCommand<Movie>((m) => this.navigationTask = MvxNotifyTask.Create(this.NavigateToMovieDetailCommandExecute(m)));

            this.Movies = new MvxObservableCollection<Movie>();
            this.Text = "Blade Runner";
        }

        private Task<bool> NavigateToMovieDetailCommandExecute(Movie m)
        {
            return NavigationService.MvxNavigationService.Navigate<MovieDetailViewModel,Movie>(m);
        }

        public MvxObservableCollection<Movie> Movies { get; set; }

        private async Task SearchCommandExecute()
        {
            var list = await this.moviesService.SearchMovies(this.Text);
            var movies = EntitiesToUi.ConvertMovies(list);
            this.FillMovies(movies);
        }

        private void FillMovies(IEnumerable<Movie> movies)
        {
            this.Movies.Clear();
            foreach (var item in movies)
            {
                this.Movies.Add(item);
            }
        }

        public string Text { get => text; set => SetProperty(ref text, value); }

        public IMvxCommand SearchCommand { get; }

        public IMvxCommand NavigateToMovieDetailCommand { get; }
    }
}
