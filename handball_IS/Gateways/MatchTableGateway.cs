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

        public async Task<IEnumerable<Match>> GetMatches()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Matches";
            return await connection.QueryAsync<Match>(sql);
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
            string sql = "INSERT INTO Matches (Date, Time, HomeTeamId, AwayTeamId, RefereeId, RecorderId, CategoryId) VALUES (@Date, @Time, @HomeTeamId, @AwayTeamId, @RefereeId, @RecorderId, @CategoryId)";
            await connection.ExecuteAsync(sql, match);
        }

        public async Task UpdateMatch(Match match)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Matches SET Date = @Date, Time = @Time, HomeTeamId = @HomeTeamId, AwayTeamId = @AwayTeamId, RefereeId = @RefereeId, RecorderId = @RecorderId, CategoryId = @CategoryId WHERE Id = @Id";
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
