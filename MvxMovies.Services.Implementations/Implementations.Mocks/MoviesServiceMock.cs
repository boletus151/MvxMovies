using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvxMovies.Entities;
using MvxMovies.Services.Contracts;

namespace MvxMovies.Services.Implementations.Mocks
{
    public class MoviesServiceMock : IMoviesService
    {
        private IEnumerable<MovieDto> movies;

        public MoviesServiceMock()
        {
            this.movies = new List<MovieDto>(GetMovies());
        }

        public Task<MovieDto> GetMovieById(int id)
        {
            return Task.FromResult(this.movies.FirstOrDefault(e=>e.Id == id));
        }

        public Task<IEnumerable<MovieDto>> SearchMovies(string name)
        {
            return Task.Run(() => this.movies);
        }

        private static IEnumerable<MovieDto> GetMovies()
        {
            var random = new Random(1000);
            for (int i = 0; i < 10; i++)
            {
                yield return GetMovie(i, random);
            }
        }

        private static MovieDto GetMovie(int i, Random random = null)
        {
            if (random == null)
            {
                random = new Random(1000);
            }
            return new MovieDto
            {
                Id = i,
                Image = "https://atasouthport.com/wp-content/uploads/2017/04/default-image.jpg",
                Title = $"Title {i}",
                Plot = $"Plot {i}",
                Rating = random.Next(1, 5)
            };
        }
    }
}
