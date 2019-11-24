using System;
using System.Threading.Tasks;
using MonkeyCache.FileStore;
using MvxMovies.Common.Contracts;
using MvxMovies.Common.Constants;

namespace MvxMovies.Common.Implementations
{
    public class StorageServiceMonkeyCache : IStorageService
    {
        public StorageServiceMonkeyCache()
        {
            this.ForceRefresh = AppConstants.ForceRefresh;
        }

        public static int ExpirationDate => AppConstants.MaxExpirationDate;

        public bool ForceRefresh { get; set; }

        public Task ClearStorage()
        {
            try
            {
                return Task.Run(() => Barrel.Current.EmptyAll());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public Task<T> Get<T>(string key)
        {
            try
            {
                return Task.Run(() => Barrel.Current.Get<T>(key));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public Task Remove(string key)
        {
            try
            {
                return Task.Run(() => Barrel.Current.Empty(key));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public Task Set<T>(string key, T value)
        {
            try
            {
                return Task.Run(() => Barrel.Current.Add(key, value, TimeSpan.FromDays(ExpirationDate)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }
    }
}
