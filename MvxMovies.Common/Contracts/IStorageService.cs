namespace MvxMovies.Common.Contracts
{
    public interface IStorageService
    {
        /// <summary>
        /// Get the specified key.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="key">Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T Get<T>(string key);

        /// <summary>
        /// Set the specified key and value.
        /// </summary>
        /// <returns>The set.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        void Set<T>(string key, T value);

        /// <summary>
        /// Remove the specified key.
        /// </summary>
        /// <returns>The remove.</returns>
        /// <param name="key">Key.</param>
        void Remove(string key);

        /// <summary>
        /// Remove everything from the storage
        /// </summary>
        /// <returns></returns>
        void ClearStorage();
    }
}
