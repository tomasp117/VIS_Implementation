using handball_IS.Gateways;
using handball_IS.Modules;
using handball_IS.Objects;
using Microsoft.AspNetCore.Mvc;

namespace handball_IS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {

        private readonly TournamentModule tournamentModule;

        public TournamentsController(TournamentModule tournamentModule)
        {
            this.tournamentModule = tournamentModule;
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament([FromBody] Tournament tournament)
        {
            if (string.IsNullOrEmpty(tournament.Name))
            {
                return BadRequest("Tournament name is required.");
            }

            await tournamentModule.AddTournament(tournament);

            return Ok();
        }

        // private readonly TournamentTableGateway tournamentTableGateway;


        //public TournamentsController(TournamentTableGateway tournamentTableGateway)
        //{
        //    this.tournamentTableGateway = tournamentTableGateway;
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddTournament([FromBody] Tournament tournament)
        //{
        //    if (string.IsNullOrEmpty(tournament.Name))
        //    {
        //        return BadRequest("Tournament name is required.");
        //    }

        //    await tournamentTableGateway.InsertTournament(tournament);
        //    return Ok();
        //}
    }
}
