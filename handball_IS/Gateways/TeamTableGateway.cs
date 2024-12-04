using handball_IS.Objects;
using handball_IS.Utils;
using Microsoft.AspNetCore.Connections;
using Dapper;


namespace handball_IS.Gateways
{
    public class TeamTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public TeamTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Team>> GetTeams()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams";
            return await connection.QueryAsync<Team>(sql);
            
        }

        public async Task<Team> GetTeamById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Team>(sql, new { Id = id });
        }

        public async Task InsertTeam(Team team)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Teams (Name) VALUES (@Name)";
            await connection.ExecuteAsync(sql, team);
        }

        public async Task UpdateTeam(Team team)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Teams SET Name = @Name WHERE Id = @Id";
            await connection.ExecuteAsync(sql, team);
        }

        public async Task DeleteTeam(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Teams WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
