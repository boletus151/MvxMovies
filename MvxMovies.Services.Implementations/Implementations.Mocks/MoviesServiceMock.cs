using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MvxMovies.Entities;
using MvxMovies.Services.Contracts;

namespace MvxMovies.Services.Implementations.Mocks
{
    public class MoviesServiceMock : IMoviesService
    {
        private readonly IEnumerable<MovieDto> movies;

        public MoviesServiceMock()
        {
            this.movies = new List<MovieDto>(GetMovies());
        }

        public Task<MovieDto> GetMovieById(string id, CancellationToken? cancellationToken = null)
        {
            return Task.FromResult(this.movies.FirstOrDefault(e=> e.Id.Equals(id)));
        }

        public Task<IEnumerable<MovieDto>> SearchMovies(string name, CancellationToken? cancellationToken = null)
        {
            if (cancellationToken is null)
            {
                return Task.FromResult(this.movies);
            }
            var cancelToken = (CancellationToken)cancellationToken;
            return Task.Run(async() => await this.GetMoviesWithCancellation(cancelToken),cancelToken);
        }

        private Task<IEnumerable<MovieDto>> GetMoviesWithCancellation(CancellationToken cancellationToken)
        {
            var continueMethod = true;
            var list = this.movies;
            var watch = new Stopwatch();
            watch.Start();

            while (continueMethod)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    list = new List<MovieDto>();
                    break;
                }
                if (watch.ElapsedMilliseconds > 5000)
                {
                    continueMethod = false;
                }
            }
            watch.Stop();
            return Task.FromResult(list);
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
                Id = i.ToString(),
                Image = "https://atasouthport.com/wp-content/uploads/2017/04/default-image.jpg",
                Title = $"Title {i}",
                Plot = $"Plot {i}",
                Rating = random.Next(1, 5)
            };
        }
    }
}
