using System.Data;
using Categories.Core;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Categories.DAL
{
    public class PsqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public PsqlConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}