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

        public async Task<List<Player>> GetPlayers()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Players";
            return (await connection.QueryAsync<Player>(sql)).ToList();
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
            string sql = "INSERT INTO Players (Number, FirstName, LastName, GoalCount, SevenMeterGoalCount, SevenMeterMissCount, TwoMinPenaltyCount, RedCardCount, YellowCardCount, TeamId, CategoryId) VALUES (@Number, @FirstName, @LastName, @GoalCount, @SevenMeterGoalCount, @SevenMeterMissCount, @TwoMinPenaltyCount, @RedCardCount, @YellowCardCount, @TeamId, @CategoryId)";
            await connection.ExecuteAsync(sql, player);
        }

        public async Task UpdatePlayer(Player player)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Players SET Number = @Number, FirstName = @FirstName, LastName = @LastName, GoalCount = @GoalCount, SevenMeterGoalCount = @SevenMeterGoalCount, SevenMeterMissCount = @SevenMeterMissCount, TwoMinPenaltyCount = @TwoMinPenaltyCount, RedCardCount = @RedCardCount, YellowCardCount = @YellowCardCount, TeamId = @TeamId, CategoryId = @CategoryId WHERE Id = @Id";
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
