using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
namespace Tranborg.DataAccess
{
    /// <summary>
    /// Class <c>PostgreSQLDataAccess</c> is a class that implements the <c>IDataAccess</c> interface.
    /// Used to interact with a PostgreSQL database.
    /// </summary>
    public class PostgreSQLDatabaseAccess : IDatabaseAccess
    {
        /// <summary>
        /// Loads data from a PostgreSQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public List<T> LoadData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            var rows = connection.Query<T>(TSQL, parameters, commandType: commandType);
            return rows.ToList();
        }

        /// <summary>
        /// Loads data from a PostgreSQL database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public async Task<List<T>> LoadDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            var rows = await connection.QueryAsync<T>(TSQL, parameters, commandType: commandType);
            return rows.ToList();
        }

        /// <summary>
        /// Loads a single row of data from a PostgreSQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public T LoadSingleData<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            var row = connection.QueryFirstOrDefault<T>(TSQL, parameters, commandType: commandType);
            return row;
        }

        /// <summary>
        /// Loads a single row of data from a PostgreSQL database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public async Task<T> LoadSingleDataAsync<T, U>(string TSQL, U parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            var row = await connection.QueryFirstOrDefaultAsync<T>(TSQL, parameters, commandType: commandType);
            return row;
        }

        /// <summary>
        /// Saves data to a PostgreSQL database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        public void SaveData<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            connection.Execute(TSQL, parameters, commandType: commandType);
        }

        /// <summary>
        /// Saves data to a PostgreSQL database asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TSQL"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <param name="isStoredProcedure"></param>
        /// <returns></returns>
        public async Task SaveDataAsync<T>(string TSQL, T parameters, string connectionString, bool isStoredProcedure = false)
        {
            CommandType commandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
            using IDbConnection connection = new NpgsqlConnection(connectionString);
            connection.ExecuteAsync(TSQL, parameters, commandType: commandType);
        }
    }
}
