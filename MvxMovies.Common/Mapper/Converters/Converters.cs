using MvxMovies.Entities;
using MvxMovies.UI.Model;

namespace MvxMovies.Common.Mapper
{
    public static class Converters
    {
        public static Movie MovieToMovieUi(MovieDto movie) => new Movie
        {
            Title = movie.Title,
            Image = movie.Image,
            Plot = movie.Plot,
            Rating = movie.Rating
        };
    }
}
