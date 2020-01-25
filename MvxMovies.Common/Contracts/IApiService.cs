using System.Threading;
using System.Threading.Tasks;

namespace MvxMovies.Common.Contracts
{
    public interface IApiService
    {
        Task<TResult> GetData<TResult>(string parameters, CancellationToken? cancellationToken) where TResult: class;
    }
}
