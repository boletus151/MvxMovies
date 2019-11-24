using System.Threading.Tasks;

namespace MvxMovies.Common.Contracts
{
    public interface IApiService
    {
        Task<TResult> GetData<TResult>(string parameters) where TResult: class;
    }
}
