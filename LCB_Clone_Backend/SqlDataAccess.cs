using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace LCB_Clone_Backend
{

    public class SqlDataAccess
    {
        private readonly string? _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<T>> LoadData<T, U>(string query, U parameters)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                IEnumerable<T> rows = await connection.QueryAsync<T>(query, parameters);
                return rows.ToList();
            }
        }

        public async Task SaveData<T>(string query, T parameters)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
