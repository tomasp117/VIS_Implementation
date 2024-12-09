using Dapper;
using handball_IS.Objects.Actors.sub;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class RecorderTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public RecorderTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Recorder>> GetRecorders()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Recorders";
            return (await connection.QueryAsync<Recorder>(sql)).ToList();
        }

        public async Task<Recorder> GetRecorderById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Recorders WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Recorder>(sql, new { Id = id });
        }

        public async Task InsertRecorder(Recorder recorder)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Recorders (Id) VALUES (@Id)";
            await connection.ExecuteAsync(sql, recorder);
        }

        public async Task UpdateRecorder(Recorder recorder)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Recorders SET Id = @Id WHERE Id = @Id";
            await connection.ExecuteAsync(sql, recorder);
        }

        public async Task DeleteRecorder(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Recorders WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
