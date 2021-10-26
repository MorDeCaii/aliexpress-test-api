using System.Data;

namespace Categories.Core
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}