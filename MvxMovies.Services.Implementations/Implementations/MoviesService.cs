using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MvxMovies.Common.Constants;
using MvxMovies.Common.Contracts;
using MvxMovies.Entities;
using MvxMovies.Services.Contracts;
using Newtonsoft.Json;

namespace MvxMovies.Services.Implementations
{
    public class MoviesService : IMoviesService
    {
        private readonly IApiService apiService;

        public MoviesService(IApiService apiService)
        {
            this.apiService = apiService;
        }

        public async Task<MovieDto> GetMovieById(string id, CancellationToken? cancellationToken = null)
        {
            var parameters = string.Format(DataServiceConstants.MOVIE, id);
            var finalParameters = Uri.EscapeUriString(parameters);
            var response = await this.apiService.GetData<MovieDto>(finalParameters, cancellationToken);

            return response;
        }

        public async Task<IEnumerable<MovieDto>> SearchMovies(string name, CancellationToken? cancellationToken = null)
        {
            var parameters = string.Format(DataServiceConstants.SEARCH, name);
            var finalParameters = Uri.EscapeUriString(parameters);

            var response = await this.apiService.GetData<SearchMovies>(finalParameters, cancellationToken);

            return response.Search ?? new List<MovieDto>();
        }
    }
}
