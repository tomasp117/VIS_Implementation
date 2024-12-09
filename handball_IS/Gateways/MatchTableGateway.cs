using Dapper;
using handball_IS.Utils;
using System.Text.RegularExpressions;

namespace handball_IS.Gateways
{
    public class MatchTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public MatchTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Match>> GetMatches()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Matches";
            return (await connection.QueryAsync<Match>(sql)).ToList();
        }

        public async Task<Match> GetMatchById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Matches WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Match>(sql, new { Id = id });
        }

        public async Task InsertMatch(Match match)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Matches (Time, TimePlayed, Playground, Score, State, HomeTeamId, AwayTeamId, RefereeId, RecorderId, CategoryId) VALUES (@Time, @TimePlayed, @Playground, @Score, @State, @HomeTeamId, @AwayTeamId, MainRefereeId, AssistantRefereeId, GroupId)";
            await connection.ExecuteAsync(sql, match);
        }

        public async Task UpdateMatch(Match match)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Matches SET Time = @Time, TimePlayed = @TimePlayed, Playground = @Playground, Score = @Score, State = @State, HomeTeamId = @HomeTeamId, AwayTeamId = @AwayTeamId, MainRefereeId = @MainRefereeId, AssistantRefereeId = @AssistantRefereeId, GroupId = @GroupId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, match);
        }

        public async Task DeleteMatch(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Matches WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
