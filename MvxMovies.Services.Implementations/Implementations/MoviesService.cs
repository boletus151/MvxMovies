using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using MvxMovies.Entities;
using MvxMovies.Services.Contracts;

namespace MvxMovies.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IApiService apiService;

        public MoviesService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public Task<MovieDto> GetMovieById(int id, CancellationToken? cancellationToken = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MovieDto>> SearchMovies(string name, CancellationToken? cancellationToken = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
