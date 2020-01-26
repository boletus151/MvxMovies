using System;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;
using MvxMovies.Common.Mapper;
using MvxMovies.UI.Model.ReturnPageTypes;

namespace MvxMovies.Core.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel<Movie,CheckedMovie>
    {
        private readonly IMoviesService moviesService;
        private Movie movie;

        public MovieDetailViewModel(INavigationService navigationService, IMoviesService moviesService) : base(navigationService)
        {
            this.moviesService = moviesService;
            this.Movie = new Movie();
        }

        public Movie Movie { get => movie; set => SetProperty(ref movie, value); }
        public string SelectedMovieId { get; set; }

        public override void Prepare(Movie parameter)
        {
            base.Prepare(parameter);
            this.SelectedMovieId = parameter.Id;
        }

        public override async Task Initialize()
        {
            try
            {
                await base.Initialize();

                var movieDto = await this.moviesService.GetMovieById(this.SelectedMovieId);
                this.Movie = EntitiesToUi.ConvertMovie(movieDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            this.NavigationService.MvxNavigationService.Close(this, new CheckedMovie(true, this.Movie.Id));

            base.ViewDestroy(viewFinishing);
        }
    }
}
