using handball_IS.Gateways;
using handball_IS.Modules;
using Microsoft.AspNetCore.Mvc;

namespace handball_IS.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryModule categoryModule;

        public CategoryController(CategoryModule categoryModule)
        {
            this.categoryModule = categoryModule;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await categoryModule.GetCategories();
                if (categories.Count == 0)
                {
                    return NotFound(new { message = "No categories found." });
                }
                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
