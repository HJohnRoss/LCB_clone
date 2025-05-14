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

        public List<T> LoadData<T, U>(string query, U parameters)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                List<T> rows = connection.Query<T>(query, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string query, T parameters)
        {
            using (IDbConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
