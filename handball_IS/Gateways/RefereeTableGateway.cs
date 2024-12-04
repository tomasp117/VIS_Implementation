using Dapper;
using handball_IS.Objects.Actors.sub;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class RefereeTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public RefereeTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Referee>> GetReferees()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Referees";
            return await connection.QueryAsync<Referee>(sql);
        }

        public async Task<Referee> GetRefereeById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Referees WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Referee>(sql, new { Id = id });
        }

        public async Task InsertReferee(Referee referee)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Referees (FirstName, LastName, Email, PhoneNumber, Username, Password, License) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password, @License)";
            await connection.ExecuteAsync(sql, referee);
        }

        public async Task UpdateReferee(Referee referee)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Referees SET Name = @Name , Email = @Email, PhoneNumber = @PhoneNumber, Username = @Username, Password = @Password WHERE Id = @Id";
            await connection.ExecuteAsync(sql, referee);
        }

        public async Task DeleteReferee(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Referees WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
