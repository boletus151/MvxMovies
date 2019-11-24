using System;
using System.Collections.Generic;
using MvxMovies.UI.Model;
using MvxMovies.Entities;
using System.Linq;

namespace MvxMovies.Common.Mapper
{
    public static class EntitiesToUi
    {
        public static List<Movie> ConvertMovies(IEnumerable<MovieDto> list) =>
            list.ToList().ConvertAll(new Converter<MovieDto, Movie>(Converters.MovieToMovieUi));

        public static Movie ConvertMovie(MovieDto movieDto) => Converters.MovieToMovieUi(movieDto);
    }
}
