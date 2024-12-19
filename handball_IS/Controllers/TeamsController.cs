using handball_IS.Modules;
using handball_IS.Objects;
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
            this.teamModule = teamModule;
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
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{teamId}/players")]
        public async Task<IActionResult> GetPlayersByTeam(int teamId)
        {
            Console.WriteLine($"Fetching players for team ID: {teamId}");
            try
            {
                var players = await teamModule.GetAllPlayersInTeam(teamId);
                if (players == null || players.Count == 0)
                {
                    Console.WriteLine($"No players found for team ID: {teamId}");
                    return NotFound(new { message = "No players found." });
                }
                Console.WriteLine($"Players found: {players.Count}");
                return Ok(players);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching players for team ID {teamId}: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{teamId}/players")]
        public async Task<IActionResult> AddPlayerToTeam(int teamId, [FromBody] Player player)
        {
            Console.WriteLine($"Adding player to team ID: {teamId}");
            if (player == null)
            {
                return BadRequest(new { message = "Player data is required." });
            }

            try
            {
                var categoryId = await teamModule.GetCategoryIdByTeamId(teamId);
                if (categoryId == null)
                {
                    return BadRequest(new { message = "Category for the team not found." });
                }

                player.CategoryId = categoryId.Value;

                await teamModule.AddPlayerToTeam(teamId, player);
                return Ok(new { message = "Player added successfully", player });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }




    }
}
