using System.Net.Http;
using System.Threading.Tasks;
using MvxMovies.Services.Contracts;
using System;
using Newtonsoft.Json;

namespace MvxMovies.Services.Implementations
{
    public class ApiService<TResult> : IApiService where TResult : class
    {
        private const string BASE_URL = @"http://omdbapi.com/?apikey=73124429&type=movie";

        public async Task<TResult> GetData(string parameters)
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
