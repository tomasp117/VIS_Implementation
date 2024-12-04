using MySqlConnector;
using System.Data;

namespace handball_IS.Utils
{
    public class DatabaseConnectionFactory
    {
        private readonly string connectionString = string.Empty;

        public DatabaseConnectionFactory(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(this.connectionString);
        }




    }
}
