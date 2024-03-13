
namespace DataAccess
{
    public interface IDatabaseAccess
    {
        /// <summary>
        /// Loads data from a database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        List<T> LoadData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false);
        /// <summary>
        /// Loads data from a database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        Task<List<T>> LoadDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false);
        /// <summary>
        /// Loads a single row of data from a database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        T LoadSingleData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false);
        /// <summary>
        /// Loads a single row of data from a database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        Task<T> LoadSingleDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false);
        /// <summary>
        /// Saves data to a database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        void SaveData<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false);
        /// <summary>
        /// Saves data to a database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        Task SaveDataAsync<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false);
    }
}