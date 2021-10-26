using System.Data.Common;
using System.Linq;
using Categories.Core;
using Dapper;

namespace Categories.DAL.Migrations
{
    public class Database
    {
        private readonly IDbConnectionFactory _connection;

        public Database(IDbConnectionFactory connection)
        {
            _connection = connection;
        }

        public void EnsureDatabase(string dbName)
        {
            var query = "SELECT datname FROM pg_catalog.pg_database WHERE lower(datname) = lower(@name)";
            var parameters = new DynamicParameters();
            parameters.Add("name", dbName);

            using (var connection = _connection.CreateConnection())
            {
                var records = connection.Query(query, parameters);
                if (!records.Any())
                {
                    connection.Execute($"CREATE DATABASE {dbName}");
                }
            }
        }
    }
}