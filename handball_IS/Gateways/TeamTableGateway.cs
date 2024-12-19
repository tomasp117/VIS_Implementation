using handball_IS.Objects;
using handball_IS.Utils;
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

        public async Task<List<Team>> GetTeams()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams";
            return (await connection.QueryAsync<Team>(sql)).ToList();
            
        }

        public async Task<Team> GetTeamById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Team>(sql, new { Id = id });
        }

        public async Task<List<Team>> GetTeamsByCategoryId(int categoryId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams WHERE CategoryId = @CategoryId";
            return (await connection.QueryAsync<Team>(sql, new { CategoryId = categoryId })).ToList();
        }

        public async Task<IEnumerable<Team>> GetTeamsByGroup(int groupId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Teams WHERE GroupId = @GroupId";
            return await connection.QueryAsync<Team>(sql, new { GroupId = groupId });
        }

        public async Task<int?> GetCategoryIdByTeamId(int teamId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT CategoryId FROM Teams WHERE Id = @TeamId";
            return await connection.QueryFirstOrDefaultAsync<int?>(sql, new { TeamId = teamId });
        }


        public async Task<Team> GetTeamByCoach(int coachId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT t.* FROM Teams t JOIN Coach c ON t.Id = c.TeamId WHERE c.Id = @CoachId";
            return await connection.QueryFirstOrDefaultAsync<Team>(sql, new { CoachId = coachId });
        }

        public async Task InsertTeam(Team team)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Teams (Name, ClubId, TournamentInstanceId) VALUES (@Name, @ClubId, @TournamentInstanceId)";
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
