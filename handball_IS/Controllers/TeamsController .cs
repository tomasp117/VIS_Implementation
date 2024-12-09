using handball_IS.Modules;
using handball_IS.Services;
using Microsoft.AspNetCore.Mvc;

namespace handball_IS.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly TeamModule teamModule;

        public TeamsController(TeamModule teamModule)
        {
            teamModule = teamModule;
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetTeamsByCategory(int categoryId)
        {
            try
            {
                var teams = await teamModule.GetTeamsByCategory(categoryId);
                if (teams.Count == 0)
                {
                    return NotFound(new { message = "No teams found." });
                }
                return Ok(teams);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
