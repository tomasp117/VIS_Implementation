using Dapper;
using handball_IS.Objects.Actors.sub;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class AdminTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;


        public AdminTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Admin>> GetAdmins()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Admins";
            return (await connection.QueryAsync<Admin>(sql)).ToList();
        }

        public async Task<Admin> GetAdminById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Admins WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Admin>(sql, new { Id = id });
        }

        public async Task InsertAdmin(Admin admin)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Admins (Id) VALUES (@Id)";
            await connection.ExecuteAsync(sql, admin);
        }

        public async Task UpdateAdmin(Admin admin)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Admins SET Id = @Id WHERE Id = @Id";
            await connection.ExecuteAsync(sql, admin);
        }

        public async Task DeleteAdmin(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Admins WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

    }
}
