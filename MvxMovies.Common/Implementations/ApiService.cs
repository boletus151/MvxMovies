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
        protected HttpClient httpClient;

        public ApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            this.httpClient = new HttpClient(handler);
        }

        public async Task<TResult> GetData<TResult>(string parameters, CancellationToken? cancellationToken) where TResult: class
        {
            try
            {
                string url = DataServiceConstants.BASE_URL + parameters;

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            
        }
    }
}
