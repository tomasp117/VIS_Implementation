using handball_IS.Controllers;
using handball_IS.Gateways;
using handball_IS.Modules;
using handball_IS.Objects;

namespace handball_IS.Services
{
    public class TeamCategoryService
    {
        private readonly TeamTableGateway teamTableGateway;


        private readonly TournamentInstanceTableGateway tournamentInstanceTableGateway;

        public TeamCategoryService(TeamTableGateway teamTableGateway, TournamentInstanceTableGateway tournamentInstanceTableGateway)
        {
            this.teamTableGateway = teamTableGateway;
            this.tournamentInstanceTableGateway = tournamentInstanceTableGateway;
        }


        //public async Task<List<Team>> GetTeamsByCategoryAsync(int categoryId)
        //{
        //    var teams = new List<Team>();

        //    foreach (var group in groups)
        //    {
        //        var groupTeams = await teamTableGateway.GetTeamsByGroup(group.Id);
        //        teams.AddRange(groupTeams);
        //    }

        //    return teams.DistinctBy(t => t.Id).ToList();
        //}
    }
}
