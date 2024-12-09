using handball_IS.Gateways;
using handball_IS.Objects;

namespace handball_IS.Modules
{
    public class TeamModule
    {
        private readonly TeamTableGateway teamTableGateway;

        public TeamModule(TeamTableGateway teamTableGateway)
        {
            this.teamTableGateway = teamTableGateway;
        }

        public async Task AddPlayerToTeam(int teamId, Player player)
        {
            Team team = await teamTableGateway.GetTeamById(teamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            team.Players.Add(player);
            await teamTableGateway.UpdateTeam(team);
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
            Team team = await teamTableGateway.GetTeamById(teamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }
            return team.Players;
        }

        
        public async Task<List<Team>> GetTeamsByCategory(int categoryId)
        {
            List<Team> teams = await teamTableGateway.GetTeamsByCategoryId(categoryId);
            if (teams.Count == 0)
            {
                throw new Exception("No teams found.");
            }
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
