using MvxMovies.Entities;
using MvxMovies.UI.Model;

namespace MvxMovies.Common.Mapper
{
    public static class Converters
    {
        public static Movie MovieToMovieUi(MovieDto source) => new Movie
        {
            Title = source.Title ,
            Image = source.Image,
            Plot = source.Plot,
            Rating = source.Rating
        };
    }
}
