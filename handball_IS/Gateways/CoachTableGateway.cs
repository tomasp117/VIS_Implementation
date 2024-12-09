using Dapper;
using handball_IS.Objects.Actors.sub;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class CoachTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public CoachTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Coach>> GetCoaches()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Coach";
            return (await connection.QueryAsync<Coach>(sql)).ToList();
        }

        public async Task<Coach> GetCoachById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Coach WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Coach>(sql, new { Id = id });
        }

        public async Task InsertCoach(Coach coach)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Coach (Id, PlayerVoteId, GoalkeeperVoteId, License, TeamId, CategoryId) VALUES (@Id, @PlayerVoteId, @GoalkeeperVoteId, @License, @TeamId, @CategoryId)";
            await connection.ExecuteAsync(sql, coach);
        }

        public async Task UpdateCoach(Coach coach)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Coach SET Id = @Id, PlayerVoteId = @PlayerVoteId, GoalkeeperVoteId = @GoalkeeperVoteId, License = @License, TeamId = @TeamId, CategoryId = @CategoryId WHERE Id = @Id";
        }

        public async Task DeleteCoach(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Coach WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
