using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class PlayerTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public PlayerTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Players";
            return await connection.QueryAsync<Player>(sql);
        }

        public async Task<Player> GetPlayerById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Players WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Player>(sql, new { Id = id });
        }

        public async Task InsertPlayer(Player player)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Players (FirstName, LastName, DateOfBirth, Height, Weight, Position, ClubId) VALUES (@FirstName, @LastName, @DateOfBirth, @Height, @Weight, @Position, @ClubId)";
            await connection.ExecuteAsync(sql, player);
        }

        public async Task UpdatePlayer(Player player)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Players SET FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, Height = @Height, Weight = @Weight, Position = @Position, ClubId = @ClubId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, player);
        }

        public async Task DeletePlayer(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Players WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
