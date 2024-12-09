using handball_IS.Gateways;
using handball_IS.Objects;

namespace handball_IS.Modules
{
    public class TournamentModule
    {
        private readonly TournamentTableGateway tournamentTableGateway;

        public TournamentModule(TournamentTableGateway tournamentTableGateway)
        {
            this.tournamentTableGateway = tournamentTableGateway;
        }

        public async Task AddTournament(Tournament tournament)
        {
            await tournamentTableGateway.InsertTournament(tournament);
        }
    }
}
