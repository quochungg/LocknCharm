using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs;
using LocknCharm.Application.DTOs.Category;
using LocknCharm.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<APIResponse>> GetCategories(string? searchName, int index = 1, int pageSize = 10)
        {
            var categories = await _categoryService.GetPaginatedListAsync(searchName, index, pageSize);
            return APIResponse.Success(200, "Get list categories successful!", categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetCategoryById(string id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return APIResponse.Success(200, $"Get category {id} successful!", category);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CreateCategoryDTO category)
        {
            var created = await _categoryService.CreateAsync(category);
            return APIResponse.Success(201, $"Create category {created.Id} successful!", created);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<APIResponse>> UpdateCategory([FromBody] UpdateCategoryDTO category)
        {
            var updated = await _categoryService.UpdateAsync(category);
            return APIResponse.Success(200, $"Update category {updated.Id} successful!", updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<APIResponse>> DeleteCategory(string id)
        {
            var isDeleted = await _categoryService.DeleteAsync(id);
            return APIResponse.Success(204, $"Delete category {id} successful!");
        }
    }
}
