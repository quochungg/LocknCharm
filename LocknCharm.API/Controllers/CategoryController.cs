using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = new[]
            {
                new { Id = 1, Name = "Keychains" },
                new { Id = 2, Name = "Accessories" }
            };

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = new { Id = id, Name = $"Category {id}" };

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CreateCategoryDTO category)
        {
            var created = await _categoryService.CreateAsync(category);
            return APIResponse.Success(201, created);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] UpdateCategoryDTO category)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return NoContent();
        }
    }
}
