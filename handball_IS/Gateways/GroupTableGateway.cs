using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;


namespace handball_IS.Gateways
{
    public class GroupTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public GroupTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Group>> GetGroups()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Groups";
            return (await connection.QueryAsync<Group>(sql)).ToList();
        }

        public async Task<Group> GetGroupById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM `Groups` WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Group>(sql, new { Id = id });
        }

        public async Task<List<Group>> GetGroupsByCategory(int categoryId)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM `Groups` WHERE CategoryId = @CategoryId";
            return (await connection.QueryAsync<Group>(sql, new { CategoryId = categoryId })).ToList();
        }

        public async Task InsertGroup(Group group)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Groups (Name, CategoryId) VALUES (@Name, @CategoryId)";
            await connection.ExecuteAsync(sql, group);
        }

        public async Task UpdateGroup(Group group)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Groups SET Name = @Name, CategoryId = @CategoryId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, group);
        }

        public async Task DeleteGroup(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Groups WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
