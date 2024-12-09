using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class CategoryTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public CategoryTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<List<Category>> GetCategories()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Categories";
            return (await connection.QueryAsync<Category>(sql)).ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Categories WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Category>(sql, new { Id = id });
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Categories WHERE Name = @CategoryName";
            return await connection.QueryFirstOrDefaultAsync<Category>(sql, new { CategoryName = categoryName });
        }

        public async Task InsertCategory(Category category)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Categories (Name, VotingOpen, TournamentInstanceId) VALUES (@Name, @VotingOpen, @TournamentInstanceId)";
            await connection.ExecuteAsync(sql, category);
        }

        public async Task UpdateCategory(Category category)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Categories SET Name = @Name, VotingOpen = @VotingOpen, TournamentInstanceId = @TournamentInstanceId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, category);
        }

        public async Task DeleteCategory(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Categories WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

    }
}
