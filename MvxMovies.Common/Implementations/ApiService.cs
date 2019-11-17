using System.Net.Http;
using System.Threading.Tasks;
using MvxMovies.Common.Contracts;
using System;
using Newtonsoft.Json;

namespace MvxMovies.Common.Implementations
{
    public class ApiService : IApiService
    {
        private const string BASE_URL = @"http://omdbapi.com/?apikey=73124429&type=movie";

        public async Task<TResult> GetData<TResult>(string parameters) where TResult: class
        {
            using (var httpClient = new HttpClient())
            {
                string url = BASE_URL + @"&t=" + Uri.EscapeDataString(parameters);

                var response = await httpClient.GetAsync(url);

                string jsonMovie = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResult>(jsonMovie);
            }
        }
    }
}
