using System.Net.Http;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using System;
using Newtonsoft.Json;
using System.Threading;
using MvxMovies.Common.Constants;

namespace MvxMovies.Common.Implementations
{
    public class ApiService : IApiService
    {

        public async Task<TResult> GetData<TResult>(string parameters, CancellationToken? cancellationToken) where TResult: class
        {
            using (var httpClient = new HttpClient())
            {
                string url = DataServiceConstants.BASE_URL + parameters;

                var cancelToken = (CancellationToken)cancellationToken;

                HttpResponseMessage response;

                if (cancellationToken is null)
                {
                    response = await httpClient.GetAsync(url);
                }
                else
                {
                    response = await httpClient.GetAsync(url, (CancellationToken)cancellationToken);
                } 

                string jsonMovie = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResult>(jsonMovie);
            }
        }
    }
}
