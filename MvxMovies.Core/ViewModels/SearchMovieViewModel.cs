using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxMovies.Common.Mapper;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;
using MvxMovies.UI.Model.ReturnPageTypes;

namespace MvxMovies.Core.ViewModels
{
    public class SearchMovieViewModel : MvxBaseViewModel<object, ReturnTypeBase>
    {
        private readonly IMoviesService moviesService;
        private string text;
        private bool searchCancelled;

        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private string errorMessageString;

        public SearchMovieViewModel(IBaseViewModel baseViewModel, IMoviesService moviesService) : base(baseViewModel)
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
            //await this.BaseViewModel.DialogService.ShowDefaultLoadingDialog();
            // mock this passing desired value
            // After this method InitializeTask_PropertyChanged will raise
            if (!await this.BaseViewModel.AccessAllowed(true)) return;

            await this.SearchCommandExecute();
        }

        private async Task NavigateToMovieDetailCommandExecute(Movie m)
        {
            var result = await this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<MovieDetailViewModel, Movie, CheckedMovie>(m);
            ReturningToViewModel(result);
        }

        protected override void ReturningToViewModel(ReturnTypeBase result)
        {
            if (result is CheckedMovie checkedMovie)
            {
                var movie = this.Movies.FirstOrDefault(e => e.Id.Equals(checkedMovie.CheckedMovieId));
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
                //using (this.BaseViewModel.DialogService.ShowDefaultLoadingDialog())
                //{
                //    this.ErrorMessageIsVisible = false;

                //    this.InitCancellationToken();
                //    var list = await this.moviesService.SearchMovies(this.Text, this.cancellationToken);

                //    var movies = EntitiesToUi.ConvertMovies(list);
                //    this.FillMovies(movies);
                //}

                await this.BaseViewModel.DialogService.ShowDefaultLoadingDialog(funcLoad, null, true);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.ErrorMessageString = ex.Message;
                this.ErrorMessageIsVisible = true;
            }
            finally
            {
                this.DisposeCancellationToken();
            }
        }

        private async Task funcLoad(IProgress<double> arg)
        {
            this.ErrorMessageIsVisible = false;
            await Task.Delay(10000);
            this.InitCancellationToken();
            var list = await this.moviesService.SearchMovies(this.Text, this.cancellationToken);

            var movies = EntitiesToUi.ConvertMovies(list);
            this.FillMovies(movies);
        }

        private void DisposeCancellationToken()
        {
            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Dispose();
                this.cancellationTokenSource = null;
            }
        }

        private void InitCancellationToken()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = cancellationTokenSource.Token;
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
