using Dapper;
using handball_IS.Objects.Actors.super;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class PersonTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;
        public PersonTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }
        public async Task<List<Person>> GetPersons()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Person";
            return (await connection.QueryAsync<Person>(sql)).ToList();
        }
        public async Task<Person> GetPersonById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Person WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }

        public async Task<int?> GetCoachIdByPersonId(int personId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT Id FROM Coach WHERE Id = @PersonId";
            return await connection.QueryFirstOrDefaultAsync<int?>(sql, new { PersonId = personId });
        }

        public async Task<Person> GetPersonByUsername(string username)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Person WHERE Username = @Username";
            return await connection.QueryFirstOrDefaultAsync<Person>(sql, new { Username = username });
        }
        public async Task InsertPerson(Person person)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Person (FirstName, LastName, Email, PhoneNumber, Username, Password) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password)";
            await connection.ExecuteAsync(sql, person);
        }
        public async Task UpdatePerson(Person person)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Username = @Username, Password = @Password WHERE Id = @Id";
            await connection.ExecuteAsync(sql, person);
        }
        public async Task DeletePerson(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Person WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
        public async Task<string> GetRoleByPersonId(int personId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();

            // Dotaz pro zjištění role
            string sql = @"
                SELECT 'Admin' AS Role FROM Admin WHERE Id = @PersonId
                UNION ALL
                SELECT 'Coach' AS Role FROM Coach WHERE Id = @PersonId
                UNION ALL
                SELECT 'Referee' AS Role FROM Referee WHERE Id = @PersonId
                UNION ALL
                SELECT 'Recorder' AS Role FROM Recorder WHERE Id = @PersonId
                LIMIT 1;";

            return await connection.QueryFirstOrDefaultAsync<string>(sql, new { PersonId = personId });
        }
    }
}
