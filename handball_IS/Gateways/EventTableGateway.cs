using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class EventTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public EventTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Event>> GetEvents()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Events";
            return (await connection.QueryAsync<Event>(sql)).ToList();
        }

        public async Task<Event> GetEventById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Events WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Event>(sql, new { Id = id });
        }

        public async Task InsertEvent(Event @event)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Events (Type, Team, Time, AuthorId, MatchId) VALUES (@Type, @Team, @Time, @AuthorId, @MatchId)";
            await connection.ExecuteAsync(sql, @event);
        }

        public async Task UpdateEvent(Event @event)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Events SET Type = @Type, Team = @Team, Time = @Time, AuthorId = @AuthorId, MatchId = @MatchId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, @event);
        }

        public async Task DeleteEvent(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Events WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
