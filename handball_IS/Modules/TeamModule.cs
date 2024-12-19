using handball_IS.Gateways;
using handball_IS.Objects;

namespace handball_IS.Modules
{
    public class TeamModule
    {
        private readonly TeamTableGateway teamTableGateway;
        private readonly PlayerTableGateway playerTableGateway;


        public TeamModule(TeamTableGateway teamTableGateway, PlayerTableGateway playerTableGateway)
        {
            this.teamTableGateway = teamTableGateway;
            this.playerTableGateway = playerTableGateway;
        }

        public async Task AddPlayerToTeam(int teamId, Player player)
        {
            Console.WriteLine($"[DEBUG] Adding player to team with ID: {teamId}");
            Console.WriteLine($"[DEBUG] Player data received: {player.FirstName} {player.LastName}, Number: {player.Number}");

            // Získání CategoryId
            var categoryId = await teamTableGateway.GetCategoryIdByTeamId(teamId);
            if (categoryId == null)
            {
                Console.WriteLine($"[ERROR] No category found for team ID: {teamId}");
                throw new Exception("Category not found for the specified team.");
            }

            Console.WriteLine($"[DEBUG] Resolved category ID: {categoryId}");
            player.CategoryId = categoryId.Value;

            // Vložení hráče
            await playerTableGateway.InsertPlayer(player);
            Console.WriteLine("[DEBUG] Player successfully inserted.");
        }


        public async Task<int?> GetCategoryIdByTeamId(int teamId)
        {
            var team = await teamTableGateway.GetTeamById(teamId);
            return team?.CategoryId;
        }



        public async Task RemovePlayerFromTeam(int teamId, int playerId)
        {
            Team team = await teamTableGateway.GetTeamById(teamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }
            Player player = team.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
            {
                throw new Exception("Player not found");
            }
            team.Players.Remove(player);
            await teamTableGateway.UpdateTeam(team);
        }

        public async Task<List<Player>> GetAllPlayersInTeam(int teamId)
        {
            var players = await playerTableGateway.GetPlayersByTeamId(teamId);
            return players?.ToList() ?? new List<Player>();
        }

        
        public async Task<List<Team>> GetTeamsByCategory(int categoryId)
        {
            List<Team> teams = await teamTableGateway.GetTeamsByCategoryId(categoryId);
            if (teams.Count == 0)
            {
                throw new Exception("No teams found.");
            }
            Console.WriteLine(teams);
            return teams;
        }

        public async Task<Team> GetTeamByCoach(int coachId)
        {
            Team team = await teamTableGateway.GetTeamByCoach(coachId);
            if (team == null)
            {
                throw new Exception("No team found for this coach.");
            }
            return team;
        }
    }
}
