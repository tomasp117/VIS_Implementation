﻿using Dapper;
using handball_IS.Objects;
using handball_IS.Utils;

namespace handball_IS.Gateways
{
    public class TournamentInstanceTableGateway
    {
        private readonly DatabaseConnectionFactory databaseConnectionFactory;

        public TournamentInstanceTableGateway(DatabaseConnectionFactory databaseConnectionFactory)
        {
            this.databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<TournamentInstance>> GetTournamentInstances()
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM TournamentInstances";
            return await connection.QueryAsync<TournamentInstance>(sql);

        }

        public async Task<TournamentInstance> GetTournamentInstanceById(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "SELECT * FROM TournamentInstances WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<TournamentInstance>(sql, new { Id = id });
        }

        public async Task InsertTournamentInstance(TournamentInstance tournamentInstance)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "INSERT INTO TournamentInstances (Name, TournamentId, StartDate, EndDate) VALUES (@Name, @TournamentId, @StartDate, @EndDate)";
            await connection.ExecuteAsync(sql, tournamentInstance);
        }

        public async Task UpdateTournamentInstance(TournamentInstance tournamentInstance)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "UPDATE TournamentInstances SET Name = @Name, TournamentId = @TournamentId, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";
            await connection.ExecuteAsync(sql, tournamentInstance);
        }

        public async Task DeleteTournamentInstance(int id)
        {
            using var connection = databaseConnectionFactory.CreateConnection();
            string sql = "DELETE FROM TournamentInstances WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}