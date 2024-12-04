using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class ClubTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public ClubTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Club>> GetClubs()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Clubs";
            return await connection.QueryAsync<Club>(sql);
        }

        public async Task<Club> GetClubById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Clubs WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Club>(sql, new { Id = id });
        }

        public async Task InsertClub(Club club)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Clubs (Name, Logo, Email) VALUES (@Name, @Logo, @Email)";
            await connection.ExecuteAsync(sql, club);
        }

        public async Task UpdateClub(Club club)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Clubs SET Name = @Name, Logo = @Logo, Email = @Email WHERE Id = @Id";
            await connection.ExecuteAsync(sql, club);
        }

        public async Task DeleteClub(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Clubs WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
