using System;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Core.ViewModels.Base;
using MvxMovies.UI.Model;

namespace MvxMovies.Core.ViewModels
{
    public class MovieDetailViewModel : BaseViewModel<Movie>
    {
        public MovieDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public Movie Movie { get; set; }

        public override void Prepare(Movie parameter)
        {
            base.Prepare(parameter);
            this.Movie = parameter;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            // do the heavy work here
        }
    }
}
