using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Mapper;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;
using MvxMovies.UI.Model.ReturnPageTypes;

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
            this.NavigateToMovieDetailCommand = new MvxAsyncCommand<Movie>((m) => this.NavigateToMovieDetailCommandExecute(m));

            this.Movies = new MvxObservableCollection<Movie>();
            this.Text = "Blade Runner";
        }
        
        public string Text { get => text; set => SetProperty(ref text, value); }

        public MvxObservableCollection<Movie> Movies { get; set; }

        public IMvxCommand SearchCommand { get; }

        public IMvxCommand NavigateToMovieDetailCommand { get; }

        public override async Task Initialize()
        {
            await this.SearchCommandExecute();
        }

        private async Task NavigateToMovieDetailCommandExecute(Movie m)
        {
            var result = await NavigationService.MvxNavigationService.Navigate<MovieDetailViewModel, Movie, CheckedMovie>(m);
            var checkedMovie = result as CheckedMovie;
            if (checkedMovie != null)
            {
                var movie = this.Movies.FirstOrDefault(e => e.Id == checkedMovie.CheckedMovieId);
                if (movie != null)
                {
                    movie.Checked = true;
                }
            }
        }
        
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
    }
}
