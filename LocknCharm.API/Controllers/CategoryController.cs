using Microsoft.AspNetCore.Mvc;

namespace LocknCharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
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
        public IActionResult CreateCategory([FromBody] CategoryDto category)
        {
            return CreatedAtAction(nameof(GetCategoryById), new { id = 999 }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryDto category)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return NoContent();
        }
    }

    public class CategoryDto
    {
        public string Name { get; set; }
    }
}
