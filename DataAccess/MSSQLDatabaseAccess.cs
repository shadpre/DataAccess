using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    /// <summary>
    /// Class <c>MSSQLDataAccess</c> is a class that implements the <c>IDataAccess</c> interface.
    /// Used to interact with a Microsoft SQL Server database.
    /// </summary>
    public class MSSQLDatabaseAccess : IDatabaseAccess
    {
        /// <summary>
        /// Asynchronously loads data from a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        /// <returns>Returns a List of requested objects</returns>
        public async Task<List<T>> LoadDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = await connection.QueryAsync<T>(TSQL, parameters, commandType: commandType);
            return rows.ToList();
        }

        /// <summary>
        /// Asynchronously saves data to a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        /// <returns></returns>
        public async Task SaveDataAsync<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            connection.ExecuteAsync(TSQL, parameters, commandType: commandType);
        }

        /// <summary>
        /// Asynchronously loads a single row of data from a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        /// <returns></returns>
        public async Task<T> LoadSingleDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            var row = await connection.QueryFirstOrDefaultAsync<T>(TSQL, parameters, commandType: commandType);
            return row;
        }
        /// <summary>
        /// Loads data from a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        /// <returns></returns>
        public List<T> LoadData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = connection.Query<T>(TSQL, parameters, commandType: commandType);
            return rows.ToList();
        }

        /// <summary>
        /// Saves data to a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        public void SaveData<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Execute(TSQL, parameters, commandType: commandType);
        }

        /// <summary>
        /// Loads a single row of data from a Microsoft SQL Server database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL">The TSQL statement to be executed</param>
        /// <param name="parameters">The parmeters related to the TSQL</param>
        /// <param name="connectionString">The connection string to the database</param>
        /// <param name="isStoredProcedure">True if TSQL is the name of a stored procedure</param>
        /// <returns></returns>
        public T LoadSingleData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new SqlConnection(connectionString);
            var row = connection.QueryFirstOrDefault<T>(TSQL, parameters, commandType: commandType);
            return row;
        }
    }
}
