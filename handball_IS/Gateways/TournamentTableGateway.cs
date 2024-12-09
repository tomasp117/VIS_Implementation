using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class TournamentTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public TournamentTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Tournament>> GetTournaments()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Tournaments";
            return (await connection.QueryAsync<Tournament>(sql)).ToList();
        }

        public async Task<Tournament> GetTournamentById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Tournaments WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Tournament>(sql, new { Id = id });
        }

        public async Task InsertTournament(Tournament tournament)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Tournaments (Name) VALUES (@Name)";
            await connection.ExecuteAsync(sql, tournament);
        }

        public async Task UpdateTournament(Tournament tournament)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Tournaments SET Name = @Name WHERE Id = @Id";
            await connection.ExecuteAsync(sql, tournament);
        }

        public async Task DeleteTournament(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Tournaments WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
