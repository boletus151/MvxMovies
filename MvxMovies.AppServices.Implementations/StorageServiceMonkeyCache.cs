using System;
using MonkeyCache.FileStore;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Constants;

namespace MvxMovies.AppServices.Implementations
{
    public class StorageServiceMonkeyCache : IStorageService
    {
        public int ExpirationDate => AppConstants.MaxExpirationDate;

        public bool ForceRefresh => AppConstants.ForceRefresh;
        
        public void ClearStorage()
        {
            try
            {
               Barrel.Current.EmptyAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public T Get<T>(string key)
        {
            try
            {
                return Barrel.Current.Get<T>(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public void Remove(string key)
        {
            try
            {
                Barrel.Current.Empty(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }

        public void Set<T>(string key, T value)
        {
            try
            {
                Barrel.Current.Add(key, value, TimeSpan.FromDays(ExpirationDate));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{AppConstants.MvxMovieException}: {this.GetType().FullName}: {ex.Message}");
                throw;
            }
        }
    }
}
