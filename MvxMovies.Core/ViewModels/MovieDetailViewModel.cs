using System;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.Services.Contracts;
using MvxMovies.UI.Model;
using MvxMovies.Common.Mapper;

namespace MvxMovies.Core.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel<Movie>
    {
        private readonly IMoviesService moviesService;
        private Movie movie;

        public MovieDetailViewModel(INavigationService navigationService, IMoviesService moviesService) : base(navigationService)
        {
            this.moviesService = moviesService;
        }

        public Movie Movie { get => movie; set => SetProperty(ref movie, value); }

        public override void Prepare(Movie parameter)
        {
            base.Prepare(parameter);
            this.Movie = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var movieDto = await this.moviesService.GetMovieById(this.Movie.Id);
            this.Movie = EntitiesToUi.ConvertMovie(movieDto);
        }
    }
}
