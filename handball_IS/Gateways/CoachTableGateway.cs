﻿using Dapper;
using handball_IS.Objects.Actors.sub;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class CoachTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public CoachTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Coach>> GetCoaches()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Coaches";
            return await connection.QueryAsync<Coach>(sql);
        }

        public async Task<Coach> GetCoachById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM Coaches WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Coach>(sql, new { Id = id });
        }

        public async Task InsertCoach(Coach coach)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO Coaches (FirsName, LastName, Emial, PhoneNumber, Username, Password, License, PlayerVotedId, GoalkeeperVotedId, TeamId, CategoryId) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Username, @Password, @License, @PlayerVotedId, @GoalkeeperVotedId, @TeamId, @CategoryId)";
            await connection.ExecuteAsync(sql, coach);
        }

        public async Task UpdateCoach(Coach coach)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE Coaches SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Username = @Username, Password = @Password, License = @License, PlayerVotedId = @PlayerVotedId, GoalkeeperVotedId = @GoalkeeperVotedId, TeamId = @TeamId, CategoryId = @CategoryId WHERE Id = @Id";
            await connection.ExecuteAsync(sql, coach);
        }

        public async Task DeleteCoach(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM Coaches WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
