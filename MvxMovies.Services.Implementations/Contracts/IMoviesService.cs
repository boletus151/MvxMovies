using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MvxMovies.Entities;

namespace MvxMovies.Services.Contracts
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieDto>> SearchMovies(string name, CancellationToken? cancellationToken = null);

        Task<MovieDto> GetMovieById(int id, CancellationToken? cancellationToken = null);
    }
}
