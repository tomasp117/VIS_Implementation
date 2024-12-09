using handball_IS.Modules;
using Microsoft.AspNetCore.Mvc;

namespace handball_IS.Controllers
{
    [ApiController]
    [Route("api/coaches")]
    public class CoachesController : ControllerBase
    {
        private readonly TeamModule teamModule;

        public CoachesController(TeamModule teamModule)
        {
            this.teamModule = teamModule;
        }

        [HttpGet("{coachId}/team")]
        public async Task<IActionResult> GetTeamByCoach(int coachId)
        {
            try
            {
                var team = await teamModule.GetTeamByCoach(coachId);
                if (team == null)
                {
                    return NotFound(new { message = "No team found for this coach." });
                }

                return Ok(team);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
