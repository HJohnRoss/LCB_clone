using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Data;
using Dapper;

namespace LCB_Clone_Backend
{
    internal class SqlDataAccess
    {
        public List<T> LoadData<T, U>(string query, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(query, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string query, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqliteConnection(connectionString))
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
