using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Mapper;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;
using MvxMovies.UI.Model.ReturnPageTypes;
using Xamarin.Forms;

namespace MvxMovies.Core.ViewModels
{
    public class SearchMovieViewModel : BaseViewModel
    {
        private readonly IMoviesService moviesService;
        private string text;
        private bool searchCancelled;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private string errorMessageString;

        public SearchMovieViewModel(INavigationService navigationService, IMoviesService moviesService, IStorageService storageService) : base(navigationService, storageService)
        {
            this.moviesService = moviesService;

            this.SearchCommand = new MvxAsyncCommand(async () => await this.SearchCommandExecute());
            this.CancelAllTasksCommand = new MvxAsyncCommand(async () => await this.CancelAllTasksCommandExecute());
            this.NavigateToMovieDetailCommand = new MvxAsyncCommand<Movie>((m) => this.NavigateToMovieDetailCommandExecute(m));
            this.ErrorMessageIsVisible = false;
            this.Movies = new MvxObservableCollection<Movie>();
            this.Text = "Blade Runner";
        }

        public string Text { get => text; set => SetProperty(ref text, value); }
        public string ErrorMessageString { get => errorMessageString; set => SetProperty(ref errorMessageString, value); }
        public bool ErrorMessageIsVisible { get => searchCancelled; set => SetProperty(ref searchCancelled, value); }

        public MvxObservableCollection<Movie> Movies { get; set; }

        public IMvxCommand SearchCommand { get; }

        public IMvxCommand CancelAllTasksCommand { get; }

        public IMvxCommand NavigateToMovieDetailCommand { get; }

        public override async Task Initialize()
        {
            // mock this passing desired value
            // After this method InitializeTask_PropertyChanged will raise
            if (!this.AccessAllowed(true)) return;

            await this.SearchCommandExecute();
        }

        private async Task NavigateToMovieDetailCommandExecute(Movie m)
        {
            var result = await NavigationService.MvxNavigationService.Navigate<MovieDetailViewModel, Movie, CheckedMovie>(m);
            ReturningToViewModel(result);
        }

        protected override void ReturningToViewModel(ReturnTypeBase result)
        {
            if (result is CheckedMovie checkedMovie)
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
            try
            {
                this.ErrorMessageIsVisible = false;
                this.cancellationTokenSource = new CancellationTokenSource();
                this.cancellationToken = cancellationTokenSource.Token;

                var list = await this.moviesService.SearchMovies(this.Text, cancellationToken);
                var movies = EntitiesToUi.ConvertMovies(list);
                this.FillMovies(movies);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.ErrorMessageString = ex.Message;
                this.ErrorMessageIsVisible = true;
            }
            finally
            {
                this.cancellationTokenSource.Dispose();
                this.cancellationTokenSource = null;
            }
        }

        private Task CancelAllTasksCommandExecute()
        {
            if (this.cancellationTokenSource is null)
            {
                return Task.CompletedTask;
            }
            this.cancellationTokenSource.Cancel();
            this.ErrorMessageIsVisible = true;
            this.ErrorMessageString = "Search cancelled by the user";

            return Task.CompletedTask;
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
